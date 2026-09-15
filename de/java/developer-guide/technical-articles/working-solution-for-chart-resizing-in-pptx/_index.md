---
title: Arbeitslösung für Diagrammgrößenanpassung in PPTX
type: docs
weight: 40
url: /de/java/working-solution-for-chart-resizing-in-pptx/
keywords:
- Diagrammgrößenanpassung
- Excel-Diagramm
- OLE-Objekt
- Diagramm einbetten
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Beheben Sie unerwartete Diagrammgrößenänderungen in PPTX beim Einbetten von Excel-OLE-Objekten mit Aspose.Slides für Java. Erfahren Sie zwei Methoden mit Code, um die Größen konsistent zu halten."
---
## **Hintergrund**

Es wurde beobachtet, dass Excel‑Diagramme, die als OLE‑Objekte in einer PowerPoint‑Präsentation über Aspose‑Komponenten eingebettet sind, nach ihrer ersten Aktivierung auf eine nicht spezifizierte Skalierung geändert werden. Dieses Verhalten führt zu einem deutlich sichtbaren Unterschied zwischen dem Zustand des Diagramms vor und nach der Aktivierung. Das Aspose‑Team hat das Problem eingehend untersucht und eine Lösung gefunden. Dieser Artikel beschreibt die Ursachen des Problems und die entsprechende Behebung.

Im [vorherigen Artikel](/slides/de/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) haben wir erklärt, wie man mit Aspose.Cells for Java ein Excel‑Diagramm erstellt und es mit Aspose.Slides for Java in eine PowerPoint‑Präsentation einbettet. Um das [Objekt‑Vorschau‑Problem](/slides/de/java/object-preview-issue-when-adding-oleobjectframe/) zu beheben, haben wir das Diagrammbild dem OLE‑Objekt‑Frame des Diagramms zugewiesen. In der Ausgabepäsentation wird das OLE‑Objekt‑Frame, das das Diagrammbild anzeigt, bei Doppelklick aktiviert und das Excel‑Diagramm geöffnet. Endbenutzer können beliebige Änderungen in der zugrundeliegenden Excel‑Arbeitsmappe vornehmen und danach durch Klicken außerhalb der aktivierten Arbeitsmappe zur entsprechenden Folie zurückkehren. Beim Zurückkehren zur Folie ändert sich die Größe des OLE‑Objekt‑Frames, wobei der Skalierungsfaktor abhängig von den ursprünglichen Größen sowohl des OLE‑Objekt‑Frames als auch der eingebetteten Excel‑Arbeitsmappe ist.

## **Ursache der Größenänderung**

Da die Excel‑Arbeitsmappe ihr eigenes Fenster hat, versucht sie beim ersten Aktivieren, ihre ursprüngliche Größe beizubehalten. Das OLE‑Objekt‑Frame hat jedoch seine eigene Größe. Laut Microsoft verhandeln Excel und PowerPoint bei der Aktivierung der Arbeitsmappe über die Größe und erhalten die korrekten Proportionen im Einbettungsprozess. Abhängig von den Unterschieden zwischen der Excel‑Fenstergröße und der Größe bzw. Position des OLE‑Objekt‑Frames kommt es zu einer Größenanpassung.

## **Funktionsfähige Lösung**

Es gibt zwei mögliche Szenarien für die Erstellung von PowerPoint‑Präsentationen mit Aspose.Slides for Java.

**Szenario 1:** Erstellung einer Präsentation basierend auf einer vorhandenen Vorlage.

**Szenario 2:** Erstellung einer Präsentation von Grund auf.

Die hier bereitgestellte Lösung gilt für beide Szenarien. Die Basis aller Lösungsansätze ist dieselbe: **die Fenstergröße des eingebetteten OLE‑Objekts muss der Größe des OLE‑Objekt‑Frames in der PowerPoint‑Folien‑Slide entsprechen**. Im Folgenden werden die beiden Ansätze zu dieser Lösung erläutert.

## **Erster Ansatz**

In diesem Ansatz lernen wir, wie man die Fenstergröße der eingebetteten Excel‑Arbeitsmappe so einstellt, dass sie der Größe des OLE‑Objekt‑Frames in der PowerPoint‑Folie entspricht.

**Szenario 1**

Angenommen, wir haben eine Vorlage definiert und möchten Präsentationen basierend darauf erstellen. Es gibt eine Form an Index 2 in der Vorlage, an der wir einen OLE‑Frame mit einer eingebetteten Excel‑Arbeitsmappe platzieren wollen. In diesem Szenario ist die Größe des OLE‑Objekt‑Frames vordefiniert – sie entspricht der Größe der Form an Index 2 in der Vorlage. Wir müssen lediglich die Fenstergröße der Arbeitsmappe auf dieselbe Größe setzen. Der folgende Code‑Auszug erfüllt diesen Zweck:

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// Setze die Fensterbreite der Arbeitsmappe in Zoll (geteilt durch 72, da PowerPoint 72 Punkte pro Zoll verwendet).
workbook.getSettings().setWindowWidthInch(slide.getShapes().get_Item(2).getWidth() / 72f);
 
// Setze die Fensterhöhe der Arbeitsmappe in Zoll.
workbook.getSettings().setWindowHeightInch(slide.getShapes().get_Item(2).getHeight() / 72f);
 
// Speichere die Arbeitsmappe in einen Speicherstrom.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Erstelle einen OLE-Objekt-Frame mit den eingebetteten Excel-Daten.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    dataInfo);
```

**Szenario 2**

Nehmen wir an, wir wollen eine Präsentation von Grund auf erstellen und einen OLE‑Objekt‑Frame beliebiger Größe mit einer eingebetteten Excel‑Arbeitsmappe einfügen. Im folgenden Code‑Auszug erstellen wir einen OLE‑Objekt‑Frame mit einer Höhe von 4 Zoll und einer Breite von 9,5 Zoll bei x = 0,5 Zoll und y = 1 Zoll auf der Folie. Anschließend setzen wir das Excel‑Arbeitsmappe‑Fenster auf dieselbe Größe – 4 Zoll Höhe und 9,5 Zoll Breite.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// Gewünschte Höhe.
int desiredHeight = 288; // 4 Zoll (4 * 72)
 
// Gewünschte Breite.
int desiredWidth = 684; // 9,5 Zoll (9.5 * 72)
 
// Definiere die Diagrammgröße mit Fenster.
chart.setSizeWithWindow(true);
 
// Setze die Fensterbreite der Arbeitsmappe in Zoll (geteilt durch 72, da PowerPoint 72 Punkte pro Zoll verwendet).
workbook.getSettings().setWindowWidthInch(desiredWidth / 72f);
 
// Setze die Fensterhöhe der Arbeitsmappe in Zoll.
workbook.getSettings().setWindowHeightInch(desiredHeight / 72f);
 
// Speichere die Arbeitsmappe in einen Speicherstrom.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Erstelle einen OLE-Objekt-Frame mit den eingebetteten Excel-Daten.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    36,  // x = 0,5 Zoll (0.5 * 72)
    72,  // y = 1 Zoll (1 * 72)
    desiredWidth,
    desiredHeight,
    dataInfo);
```

## **Zweiter Ansatz**

In diesem Ansatz lernen wir, wie man die Diagrammgröße in der eingebetteten Excel‑Arbeitsmappe so einstellt, dass sie der Größe des OLE‑Objekt‑Frames in der PowerPoint‑Folien‑Slide entspricht. Dieser Ansatz ist sinnvoll, wenn die Diagrammgröße im Voraus bekannt ist und sich nie ändert.

**Szenario 1**

Angenommen, wir haben eine Vorlage definiert und möchten Präsentationen basierend darauf erstellen. Es gibt eine Form an Index 2 in der Vorlage, an der wir einen OLE‑Frame mit einer eingebetteten Excel‑Arbeitsmappe platzieren wollen. In diesem Szenario ist die Größe des OLE‑Frames vordefiniert – sie entspricht der Größe der Form an Index 2 in der Vorlage. Wir müssen lediglich die Diagrammgröße in der Arbeitsmappe auf dieselbe Größe setzen. Der folgende Code‑Auszug erfüllt diesen Zweck:

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// Definiere die Diagrammgröße ohne Fenster.
chart.setSizeWithWindow(false);
 
// Setze die Diagrammbreite in Pixel (mit 96 multiplizieren, da Excel 96 Pixel pro Zoll verwendet).
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 72f) * 96f));
 
// Setze die Diagrammhöhe in Pixel.
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 72f) * 96f));
 
// Definiere die Druckgröße des Diagramms.
chart.setPrintSize(com.aspose.cells.PrintSizeType.CUSTOM);
 
// Speichere die Arbeitsmappe in einen Speicherstrom.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Erstelle einen OLE-Objekt-Frame mit den eingebetteten Excel-Daten.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    dataInfo);
```

**Szenario 2**:

Nehmen wir an, wir wollen eine Präsentation von Grund auf erstellen und einen OLE‑Objekt‑Frame beliebiger Größe mit einer eingebetteten Excel‑Arbeitsmappe einfügen. Im folgenden Code‑Auszug erstellen wir einen OLE‑Objekt‑Frame mit einer Höhe von 4 Zoll und einer Breite von 9,5 Zoll bei x = 0,5 Zoll und y = 1 Zoll auf der Folie. Gleichzeitig setzen wir die zugehörige Diagrammgröße auf dieselben Abmessungen: Höhe 4 Zoll, Breite 9,5 Zoll.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// Unsere gewünschte Höhe.
int desiredHeight = 288; // 4 Zoll (4 * 72)
 
// Unsere gewünschte Breite.
int desiredWidth = 684; // 9.5 Zoll (9.5 * 72)
 
// Definiere die Diagrammgröße ohne Fenster.
chart.setSizeWithWindow(false);
 
// Setze die Diagrammbreite in Pixel (durch 72 teilen, um Zoll zu erhalten, mit 96 multiplizieren, da Excel 96 Pixel pro Zoll verwendet).
chart.getChartObject().setWidth((int)((desiredWidth / 72f) * 96f));
 
// Setze die Diagrammhöhe in Pixel.
chart.getChartObject().setHeight((int)((desiredHeight / 72f) * 96f));
 
// Speichere die Arbeitsmappe in einen Speicherstrom.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Erstelle einen OLE-Objekt-Frame mit den eingebetteten Excel-Daten.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    36,  // x = 0.5 Zoll (0.5 * 72)
    72,  // y = 1 Zoll (1 * 72)
    desiredWidth,
    desiredHeight,
    dataInfo);
```

## **Fazit**

Es gibt zwei Ansätze zur Behebung des Diagramm‑Größen‑Problems. Die Wahl des Ansatzes hängt von den Anforderungen und dem Anwendungsfall ab. Beide Ansätze funktionieren gleich, egal ob die Präsentationen aus einer Vorlage oder von Grund auf erstellt werden. Außerdem gibt es keine Begrenzung für die Größe des OLE‑Objekt‑Frames in dieser Lösung.

## **FAQ**

### Warum ändert meine eingebettete Excel‑Diagrammgröße nach der Aktivierung in PowerPoint?

Das passiert, weil Excel versucht, beim ersten Aktivieren die ursprüngliche Fenstergröße wiederherzustellen, während das OLE‑Objekt‑Frame in PowerPoint eigene Abmessungen hat. PowerPoint und Excel verhandeln die Größe, um das Seitenverhältnis beizubehalten, was zu einer Größenanpassung führen kann.

### Ist es möglich, dieses Größenproblem vollständig zu verhindern?

Ja. Indem man die Fenstergröße der Excel‑Arbeitsmappe oder die Diagrammgröße vor dem Einbetten an die Größe des OLE‑Objekt‑Frames anpasst, bleibt die Diagrammgröße konsistent.

### Welchen Ansatz soll ich wählen, Fenstergröße oder Diagrammgröße setzen?

Verwenden Sie **Ansatz 1 (Fenstergröße)**, wenn Sie das Seitenverhältnis der Arbeitsmappe beibehalten und eventuell später eine Größenänderung erlauben möchten.  
Verwenden Sie **Ansatz 2 (Diagrammgröße)**, wenn die Diagrammabmessungen feststehen und sich nach dem Einbetten nicht ändern.

### Funktionieren diese Methoden sowohl für Vorlagen‑basierte als auch für neue Präsentationen?

Ja. Beide Ansätze funktionieren gleichermaßen für Präsentationen, die aus Vorlagen oder von Grund auf erstellt werden.

### Gibt es ein Limit für die Größe des OLE‑Objekt‑Frames?

Nein. Der OLE‑Frame kann beliebig groß gesetzt werden, solange er angemessen zum Arbeitsmappe‑ bzw. Diagrammgrößen‑Verhältnis skaliert.

### Kann ich diese Methoden mit Diagrammen aus anderen Tabellenkalkulationsprogrammen verwenden?

Die Beispiele sind für Excel‑Diagramme mit Aspose.Cells gedacht, die Grundprinzipien gelten jedoch auch für andere OLE‑kompatible Tabellenkalkulationsprogramme, sofern sie ähnliche Größen‑Optionen unterstützen.

## **Verwandte Abschnitte**

- [Excel‑Diagramme erstellen und als OLE‑Objekte in Präsentationen einbetten](/slides/de/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)