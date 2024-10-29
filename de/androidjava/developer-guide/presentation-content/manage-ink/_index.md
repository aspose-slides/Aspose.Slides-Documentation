---
title: Tinte verwalten
type: docs
weight: 95
url: /de/androidjava/manage-ink/
keywords: "Tinte in PowerPoint, Tintenwerkzeuge, Java Tinte, Zeichnen in PowerPoint, PowerPoint-Präsentation, Java, Aspose.Slides für Android über Java"
description: "Verwenden Sie Tintenwerkzeuge, um Objekte in PowerPoint Java zu zeichnen"
---

PowerPoint bietet die Tintenfunktion, um Ihnen das Zeichnen von nicht-standardmäßigen Figuren zu ermöglichen, die verwendet werden können, um andere Objekte hervorzuheben, Verbindungen und Prozesse darzustellen und Aufmerksamkeit auf bestimmte Elemente auf einer Folie zu lenken.

Aspose.Slides bietet alle Tintentypen (z. B. [Ink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ink/), die Sie benötigen, um Tintenobjekte zu erstellen und zu verwalten.

## **Unterschiede zwischen regulären Objekten und Tintenobjekten**

Objekte auf einer PowerPoint-Folie werden typischerweise durch Formobjekte dargestellt. Ein Formobjekt ist in seiner einfachsten Form ein Container, der den Bereich des Objekts selbst (seinen Rahmen) neben seinen Eigenschaften definiert. Letztere umfasst die Größe des Containerbereichs, die Form des Containers, den Hintergrund des Containers usw. Für weitere Informationen siehe [Shape Layout Format](https://docs.aspose.com/slides/androidjava/shape-manipulations/#access-layout-formats-for-shape).

Wenn PowerPoint jedoch mit einem Tintenobjekt zu tun hat, ignoriert es alle Eigenschaften des Objektrahmens (Containers), mit Ausnahme seiner Größe. Die Größe des Containerbereichs wird durch die Standardwerte `width` und `height` bestimmt:

![ink_powerpoint1](ink_powerpoint1.png)

## **Tintenform-Trace**

Trace ist ein grundlegendes Element oder ein Standard, der verwendet wird, um die Bahn eines Stifts aufzuzeichnen, während ein Benutzer digitale Tinte schreibt. Traces sind Aufzeichnungen, die Sequenzen verbundener Punkte beschreiben.

Die einfachste Form der Kodierung gibt die X- und Y-Koordinaten jedes Probe- und Punkts an. Wenn alle verbundenen Punkte gerendert werden, erzeugen sie ein Bild wie dieses:

![ink_powerpoint2](ink_powerpoint2.png)

## Pinsel-Eigenschaften zum Zeichnen

Sie können einen Pinsel verwenden, um Linien zu zeichnen, die die Punkte der Trace-Elemente verbinden. Der Pinsel hat seine eigene Farbe und Größe, die den Eigenschaften `Brush.Color` und `Brush.Size` entsprechen.

### **Farbe des Tintenpinsels festlegen**

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

### **Größe des Tintenpinsels festlegen**

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

Im Allgemeinen stimmen die Breite und Höhe eines Pinsels nicht überein, sodass PowerPoint die Pinselgröße nicht anzeigt (der Datenbereich ist ausgegraut). Aber wenn die Pinselbreite und -höhe übereinstimmen, zeigt PowerPoint die Größe folgendermaßen an:

![ink_powerpoint3](ink_powerpoint3.png)

Zur Klarheit wollen wir die Höhe des Tintenobjekts erhöhen und die wichtigen Dimensionen überprüfen:

![ink_powerpoint4](ink_powerpoint4.png)

Der Container (Rahmen) berücksichtigt nicht die Größe der Pinsel - er geht immer davon aus, dass die Linienstärke null ist (siehe das letzte Bild).

Um daher die sichtbare Fläche des gesamten Tintenobjekts zu bestimmen, müssen wir die Pinselgröße der Trace-Objekte berücksichtigen. Hier wurde das Zielobjekt (das handgeschriebene Text-Trace-Objekt) an die Größe des Containers (Rahmens) skaliert. Wenn sich die Größe des Containers (Rahmens) ändert, bleibt die Pinselgröße konstant und umgekehrt.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint zeigt dasselbe Verhalten beim Umgang mit Texten:

![ink_powerpoint6](ink_powerpoint6.png)

**Weiterführende Informationen**

* Um allgemein über Formen zu lesen, siehe den Abschnitt [PowerPoint Shapes](https://docs.aspose.com/slides/androidjava/powerpoint-shapes/).
* Für weitere Informationen zu effektiven Werten siehe [Shape Effective Properties](https://docs.aspose.com/slides/androidjava/shape-effective-properties/#getting-effective-font-height-value).