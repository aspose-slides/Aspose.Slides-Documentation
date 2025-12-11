---
title: Ink-Objekte in Präsentationen auf Android verwalten
linktitle: Ink verwalten
type: docs
weight: 95
url: /de/androidjava/manage-ink/
keywords:
- Ink
- Ink-Objekt
- Ink-Spur
- Ink verwalten
- Ink zeichnen
- Zeichnen
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Verwalten Sie PowerPoint-Ink-Objekte - erstellen, bearbeiten und formatieren Sie digitale Tinte mit Aspose.Slides für Android. Erhalten Sie Java-Code-Beispiele für Spuren, Pinsel-Farbe und -Größe."
---

PowerPoint bietet die Ink‑Funktion, mit der Sie nicht standardisierte Figuren zeichnen können, die verwendet werden, um andere Objekte hervorzuheben, Verbindungen und Prozesse darzustellen und die Aufmerksamkeit auf bestimmte Elemente einer Folie zu lenken. 

Aspose.Slides stellt alle Ink‑Typen (z. B. [Ink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ink/) Klasse) zur Verfügung, die Sie benötigen, um Ink‑Objekte zu erstellen und zu verwalten.

## **Unterschiede zwischen regulären Objekten und Ink‑Objekten**

Objekte auf einer PowerPoint‑Folien werden typischerweise durch Shape‑Objekte dargestellt. Ein Shape‑Objekt ist in seiner einfachsten Form ein Container, der den Bereich des Objekts selbst (seinen Rahmen) zusammen mit seinen Eigenschaften definiert. Letzteres umfasst die Größe des Containerbereichs, die Form des Containers, den Hintergrund des Containers usw. Weitere Informationen finden Sie unter [Shape Layout Format](https://docs.aspose.com/slides/androidjava/shape-manipulations/#access-layout-formats-for-shape).

Allerdings ignoriert PowerPoint bei einem Ink‑Objekt alle Eigenschaften des Objekt‑Frames (Containers) mit Ausnahme seiner Größe. Die Größe des Containerbereichs wird durch die Standardwerte `width` und `height` bestimmt:

![ink_powerpoint1](ink_powerpoint1.png)

## **Inkshape‑Spuren**

Eine Trace ist ein Basiselement bzw. ein Standard, der verwendet wird, um die Flugbahn eines Stifts aufzuzeichnen, wenn ein Benutzer digitale Tinte schreibt. Traces sind Aufzeichnungen, die Sequenzen verbundener Punkte beschreiben. 

Die einfachste Form der Kodierung gibt die X‑ und Y‑Koordinaten jedes Stichprobenpunkts an. Wenn alle verbundenen Punkte gerendert werden, entsteht ein Bild wie dieses:

![ink_powerpoint2](ink_powerpoint2.png)

## **Pinsel‑Eigenschaften zum Zeichnen**

Sie können einen Pinsel verwenden, um Linien zu zeichnen, die die Punkte der Trace‑Elemente verbinden. Der Pinsel hat seine eigene Farbe und Größe, die den Eigenschaften `Brush.Color` und `Brush.Size` entsprechen. 

### **Ink‑Pinsel‑Farbe festlegen**

Dieser Java‑Code zeigt, wie Sie die Farbe für einen Pinsel festlegen:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    IInk ink = (IInk)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IInkTrace[] traces = ink.getTraces();
    IInkBrush brush = traces[0].getBrush();
    Color brushColor = brush.getColor();
    brush.setColor(Color.RED);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Ink‑Pinsel‑Größe festlegen** 

Dieser Java‑Code zeigt, wie Sie die Größe für einen Pinsel festlegen:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    IInk ink = (IInk)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IInkTrace[] traces = ink.getTraces();
    IInkBrush brush = traces[0].getBrush();
    Dimension2D brushSize = brush.getSize();
    brush.setSize(new Dimension(5, 10));
} finally {
    if (pres != null) pres.dispose();
}
```


Im Allgemeinen stimmen Breite und Höhe eines Pinsels nicht überein, sodass PowerPoint die Pinselgröße nicht anzeigt (der Datenbereich ist ausgegraut). Wenn jedoch Breite und Höhe des Pinsels übereinstimmen, zeigt PowerPoint seine Größe folgendermaßen an:

![ink_powerpoint3](ink_powerpoint3.png)

Zur Verdeutlichung erhöhen wir die Höhe des Ink‑Objekts und betrachten die wichtigen Abmessungen: 

![ink_powerpoint4](ink_powerpoint4.png)

Der Container (Rahmen) berücksichtigt nicht die Größe der Pinsel – er geht immer davon aus, dass die Linienstärke null ist (siehe das letzte Bild). 

Daher müssen wir zur Bestimmung des sichtbaren Bereichs des gesamten Ink‑Objekts die Pinselgröße der Trace‑Objekte berücksichtigen. Hier wurde das Zielobjekt (das handschriftliche Text‑Trace‑Objekt) auf die Größe des Containers (Rahmens) skaliert. Ändert sich die Größe des Containers (Rahmens), bleibt die Pinselgröße konstant und umgekehrt. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint zeigt dasselbe Verhalten beim Umgang mit Texten:

![ink_powerpoint6](ink_powerpoint6.png)

**Weiterführende Lektüre**

* Für allgemeine Informationen zu Shapes siehe den Abschnitt [PowerPoint Shapes](https://docs.aspose.com/slides/androidjava/powerpoint-shapes/).
* Weitere Informationen zu effektiven Werten finden Sie unter [Shape Effective Properties](https://docs.aspose.com/slides/androidjava/shape-effective-properties/#getting-effective-font-height-value).