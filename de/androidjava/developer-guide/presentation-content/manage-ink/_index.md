---
title: Verwalten von Präsentations-Tintenobjekten unter Android
linktitle: Tinte verwalten
type: docs
weight: 95
url: /de/androidjava/manage-ink/
keywords:
- Tinte
- Tintenobjekt
- Tintenspur
- Tinte verwalten
- Tinte zeichnen
- Zeichnen
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Verwalten Sie PowerPoint-Tintenobjekte - Erstellen, Bearbeiten und Gestalten digitaler Tinte mit Aspose.Slides für Android. Holen Sie sich Java-Codebeispiele für Spuren, Pinsel-farbe und -größe."
---

PowerPoint stellt die Tintenfunktion bereit, mit der Sie nicht‑standardmäßige Figuren zeichnen können, die verwendet werden, um andere Objekte hervorzuheben, Verbindungen und Prozesse zu zeigen und die Aufmerksamkeit auf bestimmte Elemente einer Folie zu lenken. 

Aspose.Slides bietet alle Ink‑Typen (z. B. die Klasse [Ink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ink/) ), die Sie zum Erstellen und Verwalten von Tintenobjekten benötigen.

## **Unterschiede zwischen regulären Objekten und Tintenobjekten**

Objekte auf einer PowerPoint‑Folie werden typischerweise durch Shape‑Objekte dargestellt. Ein Shape‑Objekt ist in seiner einfachsten Form ein Container, der den Bereich des eigentlichen Objekts (sein Rahmen) zusammen mit seinen Eigenschaften definiert. Letztere umfassen die Größe des Container‑Bereichs, die Form des Containers, den Hintergrund des Containers usw. Weitere Informationen finden Sie unter [Shape Layout Format](https://docs.aspose.com/slides/androidjava/shape-manipulations/#access-layout-formats-for-shape).

Allerdings ignoriert PowerPoint, wenn es mit einem Tintenobjekt arbeitet, alle Eigenschaften des Objekt‑rahmens (Containers) mit Ausnahme seiner Größe. Die Größe des Container‑Bereichs wird durch die Standardwerte `width` und `height` bestimmt:

![ink_powerpoint1](ink_powerpoint1.png)

## **Inkshape‑Spuren**

Eine Trace ist ein Basiselement bzw. ein Standard, der die Bahn eines Stifts aufzeichnet, während ein Benutzer digitale Tinte schreibt. Traces sind Aufzeichnungen, die Sequenzen miteinander verbundener Punkte beschreiben. 

Die einfachste Form der Kodierung gibt die X‑ und Y‑Koordinaten jedes Abtastpunkts an. Wenn alle verbundenen Punkte gerendert werden, entsteht ein Bild wie dieses:

![ink_powerpoint2](ink_powerpoint2.png)

## **Pinsel‑Eigenschaften zum Zeichnen**

Sie können einen Pinsel verwenden, um Linien zu zeichnen, die die Punkte von Trace‑Elementen verbinden. Der Pinsel hat eine eigene Farbe und Größe, die den Eigenschaften `Brush.Color` und `Brush.Size` entsprechen. 

### **Ink‑Pinselfarbe festlegen**

Dieser Java‑Code zeigt Ihnen, wie Sie die Farbe für einen Pinsel festlegen:
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


### **Ink‑Pinselgröße festlegen** 

Dieser Java‑Code zeigt Ihnen, wie Sie die Größe für einen Pinsel festlegen:
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


Im Allgemeinen stimmen Breite und Höhe eines Pinsels nicht überein, sodass PowerPoint die Pinselgröße nicht anzeigt (der Datenbereich ist ausgegraut). Stimmen Breite und Höhe jedoch überein, zeigt PowerPoint die Größe wie folgt an:

![ink_powerpoint3](ink_powerpoint3.png)

Zur Veranschaulichung erhöhen wir die Höhe des Tintenobjekts und prüfen die wichtigen Abmessungen: 

![ink_powerpoint4](ink_powerpoint4.png)

Der Container (Rahmen) berücksichtigt die Größe der Pinsel nicht – er geht immer davon aus, dass die Linienstärke null ist (siehe das letzte Bild). 

Um also den sichtbaren Bereich des gesamten Tintenobjekts zu bestimmen, müssen wir die Pinselgröße der Trace‑Objekte berücksichtigen. Hier wurde das Zielobjekt (das Trace‑Objekt für handschriftlichen Text) auf die Größe des Containers (Rahmens) skaliert. Ändert sich die Größe des Containers (Rahmens), bleibt die Pinselgröße konstant und umgekehrt. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint zeigt dasselbe Verhalten bei Texten:

![ink_powerpoint6](ink_powerpoint6.png)

**Weiterführende Lektüre**

* Um mehr über Shapes im Allgemeinen zu erfahren, siehe den Abschnitt [PowerPoint Shapes](https://docs.aspose.com/slides/androidjava/powerpoint-shapes/).
* Weitere Informationen zu Wirksamkeitswerten finden Sie unter [Shape Effective Properties](https://docs.aspose.com/slides/androidjava/shape-effective-properties/#getting-effective-font-height-value).