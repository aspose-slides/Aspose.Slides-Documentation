---
title: Tinte verwalten
type: docs
weight: 95
url: /java/manage-ink/
keywords: "Tinte in PowerPoint, Tintwerkzeuge, Java Ink, Zeichnen in PowerPoint, PowerPoint-Präsentation, Java, Aspose.Slides für Java"
description: "Verwenden Sie Tintwerkzeuge, um Objekte in PowerPoint Java zu zeichnen"
---

PowerPoint bietet die Tintenfunktion, um Ihnen das Zeichnen von nicht standardisierten Figuren zu ermöglichen, die verwendet werden können, um andere Objekte hervorzuheben, Verbindungen und Prozesse darzustellen und auf bestimmte Elemente auf einer Folie aufmerksam zu machen.

Aspose.Slides bietet alle benötigten Tintenarten (z. B. [Ink](https://reference.aspose.com/slides/java/com.aspose.slides/ink/) Klasse), um Tintenobjekte zu erstellen und zu verwalten.

## **Unterschiede zwischen regulären Objekten und Tintenobjekten**

Objekte auf einer PowerPoint-Folie werden typischerweise durch Formobjekte dargestellt. Ein Formobjekt ist in seiner einfachsten Form ein Container, der den Bereich des Objekts selbst (seinen Rahmen) zusammen mit seinen Eigenschaften definiert. Letzteres umfasst die Größe des Containerbereichs, die Form des Containers, den Hintergrund des Containers usw. Weitere Informationen finden Sie unter [Shape Layout Format](https://docs.aspose.com/slides/java/shape-manipulations/#access-layout-formats-for-shape).

Wenn PowerPoint jedoch mit einem Tintenobjekt zu tun hat, ignoriert es alle Eigenschaften des Objektrahmens (Containers) außer seiner Größe. Die Größe des Containerbereichs wird durch die Standardwerte `width` und `height` bestimmt:

![ink_powerpoint1](ink_powerpoint1.png)

## **Tintenformen-Traces**

Ein Trace ist ein grundlegendes Element oder eine Norm, die verwendet wird, um die Trajektorie eines Stifts aufzuzeichnen, während ein Benutzer digitale Tinte schreibt. Traces sind Aufzeichnungen, die Sequenzen verbundener Punkte beschreiben.

Die einfachste Form der Kodierung gibt die X- und Y-Koordinaten jedes Probenpunkts an. Wenn alle verbundenen Punkte gerendert werden, erzeugen sie ein Bild wie dieses:

![ink_powerpoint2](ink_powerpoint2.png)

## Pinsel-Eigenschaften zum Zeichnen

Sie können einen Pinsel verwenden, um Linien zu zeichnen, die die Punkte von Trace-Elementen verbinden. Der Pinsel hat seine eigene Farbe und Größe, die den Eigenschaften `Brush.Color` und `Brush.Size` entsprechen.

### **Tintenpinsel-Farbe festlegen**

Dieser Java-Code zeigt Ihnen, wie Sie die Farbe für einen Pinsel festlegen:

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

### **Tintenpinsel-Größe festlegen**

Dieser Java-Code zeigt Ihnen, wie Sie die Größe für einen Pinsel festlegen:

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

Im Allgemeinen stimmen die Breite und Höhe eines Pinsels nicht überein, sodass PowerPoint die Pinselgröße nicht anzeigt (der Datenbereich ist ausgegraut). Wenn jedoch die Breite und Höhe des Pinsels übereinstimmen, zeigt PowerPoint seine Größe so an:

![ink_powerpoint3](ink_powerpoint3.png)

Zur Klarheit erhöhen wir die Höhe des Tintenobjekts und überprüfen die wichtigen Dimensionen:

![ink_powerpoint4](ink_powerpoint4.png)

Der Container (Rahmen) berücksichtigt nicht die Größe der Pinsel--er geht immer davon aus, dass die Dicke der Linie null ist (siehe das letzte Bild).

Daher müssen wir zur Bestimmung des sichtbaren Bereichs des gesamten Tintenobjekts die Pinselgröße der Trace-Objekte berücksichtigen. Hier wurde das Zielobjekt (das handschriftliche Text-Trace-Objekt) auf die Größe des Containers (Rahmen) skaliert. Wenn die Größe des Containers (Rahmen) geändert wird, bleibt die Pinselgröße konstant und umgekehrt.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint zeigt dasselbe Verhalten im Umgang mit Texten:

![ink_powerpoint6](ink_powerpoint6.png)

**Weiterführende Literatur**

* Um allgemein über Formen zu lesen, siehe den Abschnitt [PowerPoint Shapes](https://docs.aspose.com/slides/java/powerpoint-shapes/). 
* Für weitere Informationen zu effektiven Werten siehe [Shape Effective Properties](https://docs.aspose.com/slides/java/shape-effective-properties/#getting-effective-font-height-value). 