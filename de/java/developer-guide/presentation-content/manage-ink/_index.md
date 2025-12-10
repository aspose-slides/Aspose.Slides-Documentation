---
title: Verwalten von Präsentations-Tintenobjekten in Java
linktitle: Tinte verwalten
type: docs
weight: 95
url: /de/java/manage-ink/
keywords:
- Tinte
- Tintenobjekt
- Tintenspur
- Tinte verwalten
- Tinte zeichnen
- Zeichnung
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Verwalten von PowerPoint-Tintenobjekten—Erstellen, Bearbeiten & Gestalten digitaler Tinte mit Aspose.Slides für Java. Holen Sie sich Codebeispiele für Spuren, Pinsel-Farbe & Größe."
---

PowerPoint bietet die Ink‑Funktion, mit der Sie nicht‑standardmäßige Figuren zeichnen können, um andere Objekte hervorzuheben, Verbindungen und Prozesse zu zeigen und die Aufmerksamkeit auf bestimmte Elemente einer Folie zu lenken. 

Aspose.Slides stellt alle Ink‑Typen (z. B. die Klasse [Ink](https://reference.aspose.com/slides/java/com.aspose.slides/ink/)) bereit, die Sie zum Erstellen und Verwalten von Ink‑Objekten benötigen. 

## **Unterschiede zwischen regulären Objekten und Ink‑Objekten**

Objekte auf einer PowerPoint‑Folie werden typischerweise durch Shape‑Objekte dargestellt. Ein Shape‑Objekt ist in seiner einfachsten Form ein Container, der den Bereich des eigentlichen Objekts (seinen Rahmen) zusammen mit dessen Eigenschaften definiert. Letztere umfassen die Größe des Container‑Bereichs, die Form des Containers, den Hintergrund des Containers usw. Weitere Informationen finden Sie unter [Shape Layout Format](https://docs.aspose.com/slides/java/shape-manipulations/#access-layout-formats-for-shape).

Wenn PowerPoint jedoch mit einem Ink‑Objekt arbeitet, ignoriert es alle Eigenschaften des Objekt‑Rahmens (Containers) außer seiner Größe. Die Größe des Container‑Bereichs wird durch die Standardwerte `width` und `height` bestimmt:

![ink_powerpoint1](ink_powerpoint1.png)

## **Inkshape‑Spuren**

Eine Spur ist ein Basiselement oder Standard, das die Flugbahn eines Stifts aufzeichnet, während ein Benutzer digitale Tinte schreibt. Spuren sind Aufzeichnungen, die Sequenzen von verbundenen Punkten beschreiben. 

Die einfachste Form der Kodierung gibt die X‑ und Y‑Koordinaten jedes Stichprobenpunkts an. Wenn alle verbundenen Punkte gerendert werden, entsteht ein Bild wie dieses:

![ink_powerpoint2](ink_powerpoint2.png)

## **Pinsel‑Eigenschaften zum Zeichnen**

Sie können einen Pinsel verwenden, um Linien zu zeichnen, die die Punkte von Spur‑Elementen verbinden. Der Pinsel verfügt über eine eigene Farbe und Größe, die den Eigenschaften `Brush.Color` und `Brush.Size` entsprechen. 

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


In der Regel stimmen Breite und Höhe eines Pinsels nicht überein, sodass PowerPoint die Pinselgröße nicht anzeigt (der Datenbereich ist ausgegraut). Stimmen Breite und Höhe des Pinsels jedoch überein, zeigt PowerPoint die Größe wie folgt an:

![ink_powerpoint3](ink_powerpoint3.png)

Zur Veranschaulichung erhöhen wir die Höhe des Ink‑Objekts und überprüfen die relevanten Abmessungen: 

![ink_powerpoint4](ink_powerpoint4.png)

Der Container (Rahmen) berücksichtigt die Größe der Pinsel nicht – er geht stets davon aus, dass die Linienstärke Null ist (siehe das letzte Bild). 

Daher müssen wir zur Bestimmung des sichtbaren Bereichs des gesamten Ink‑Objekts die Pinselgröße der Spur‑Objekte berücksichtigen. Hier wurde das Zielobjekt (das Spur‑Objekt für handgeschriebenen Text) auf die Container‑Größe skaliert. Ändert sich die Größe des Containers (Rahmens), bleibt die Pinselgröße konstant und umgekehrt. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint zeigt dasselbe Verhalten bei Texten:

![ink_powerpoint6](ink_powerpoint6.png)

**Weiterführende Literatur**

* Allgemeine Informationen zu Shapes finden Sie im Abschnitt [PowerPoint Shapes](https://docs.aspose.com/slides/java/powerpoint-shapes/). 
* Weitere Informationen zu effektiven Werten erhalten Sie unter [Shape Effective Properties](https://docs.aspose.com/slides/java/shape-effective-properties/#getting-effective-font-height-value).