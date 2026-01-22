---
title: Ink-Objekte in Präsentationen mit JavaScript verwalten
linktitle: Ink verwalten
type: docs
weight: 95
url: /de/nodejs-java/manage-ink/
keywords:
- Tinte
- Tintenobjekt
- Tintenspur
- Tinte verwalten
- Tinte zeichnen
- Zeichnung
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Verwalten Sie PowerPoint-Ink-Objekte—erstellen, bearbeiten und stilisieren Sie digitale Tinte mit Aspose.Slides für Node.js. Erhalten Sie JavaScript-Codebeispiele für Spuren, Pinsel-Farbe und -Größe."
---

PowerPoint bietet die Ink‑Funktion, mit der Sie nicht‑standardisierte Figuren zeichnen können. Diese können verwendet werden, um andere Objekte hervorzuheben, Verbindungen und Prozesse zu zeigen und die Aufmerksamkeit auf bestimmte Elemente einer Folie zu lenken.

Aspose.Slides stellt alle Ink‑Typen (z. B. die Klasse [Ink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ink/)) bereit, die Sie zum Erstellen und Verwalten von Ink‑Objekten benötigen.

## **Unterschiede zwischen regulären Objekten und Ink‑Objekten**

Objekte auf einer PowerPoint‑Folge werden typischerweise durch Shape‑Objekte dargestellt. Ein Shape‑Objekt ist im einfachsten Fall ein Container, der den Bereich des Objekts selbst (seinen Rahmen) zusammen mit seinen Eigenschaften definiert. Letztere umfassen die Größe des Containerbereichs, die Form des Containers, den Hintergrund des Containers usw. Weitere Informationen finden Sie unter [Shape Layout Format](https://docs.aspose.com/slides/nodejs-java/shape-manipulations/#access-layout-formats-for-shape).

Wenn PowerPoint jedoch ein Ink‑Objekt verarbeitet, ignoriert es alle Eigenschaften des Objektframes (Containers) außer dessen Größe. Die Größe des Containerbereichs wird durch die Standardwerte `width` und `height` bestimmt:

![ink_powerpoint1](ink_powerpoint1.png)

## **Inkshape Traces**

Ein Trace ist ein Basis‑Element oder ein Standard, der die Trajektorie eines Stifts aufzeichnet, während ein Benutzer digitale Ink zeichnet. Traces sind Aufzeichnungen, die Sequenzen verbundener Punkte beschreiben.

Die einfachste Kodierung gibt die X‑ und Y‑Koordinaten jedes Sample‑Punktes an. Wenn alle verbundenen Punkte gerendert werden, entsteht ein Bild wie dieses:

![ink_powerpoint2](ink_powerpoint2.png)

## Brush Properties For Drawing 

Sie können einen Brush verwenden, um Linien zu zeichnen, die die Punkte der Trace‑Elemente verbinden. Der Brush hat seine eigene Farbe und Größe, die den Methoden `Brush.setColor` und `Brush.setSize` entsprechen.

### **Set Ink Brush Color**

Dieser JavaScript‑Code zeigt, wie Sie die Farbe für einen Brush festlegen:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var ink = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var traces = ink.getTraces();
    var brush = traces[0].getBrush();
    var brushColor = brush.getColor();
    brush.setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Set Ink Brush Size** 

Dieser JavaScript‑Code zeigt, wie Sie die Größe für einen Brush festlegen:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var ink = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var traces = ink.getTraces();
    var brush = traces[0].getBrush();
    var brushSize = brush.getSize();
    brush.setSize(java.newInstanceSync("java.awt.Dimension", 5, 10));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Im Allgemeinen stimmen Breite und Höhe eines Brushes nicht überein, sodass PowerPoint die Brush‑Größe nicht anzeigt (der Datenabschnitt ist ausgegraut). Stimmen Breite und Höhe jedoch überein, zeigt PowerPoint die Größe wie folgt an:

![ink_powerpoint3](ink_powerpoint3.png)

Zur Veranschaulichung erhöhen wir die Höhe des Ink‑Objekts und prüfen die wichtigen Abmessungen:

![ink_powerpoint4](ink_powerpoint4.png)

Der Container (Frame) berücksichtigt die Größe der Brushes nicht – er geht immer davon aus, dass die Linienstärke null ist (siehe das letzte Bild).

Daher müssen wir zur Bestimmung des sichtbaren Bereichs des gesamten Ink‑Objekts die Brush‑Größe der Trace‑Objekte berücksichtigen. Hier wurde das Zielobjekt (das Trace‑Objekt für handgeschriebene Texte) auf die Container‑ (Frame‑) Größe skaliert. Ändert sich die Größe des Containers (Frames), bleibt die Brush‑Größe konstant und umgekehrt.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint zeigt dasselbe Verhalten bei Texten:

![ink_powerpoint6](ink_powerpoint6.png)

**Weiterführende Literatur**

* Für allgemeine Informationen zu Shapes siehe den Abschnitt [PowerPoint Shapes](https://docs.aspose.com/slides/nodejs-java/powerpoint-shapes/).
* Weitere Informationen zu effektiven Werten finden Sie unter [Shape Effective Properties](https://docs.aspose.com/slides/nodejs-java/shape-effective-properties/#getting-effective-font-height-value).