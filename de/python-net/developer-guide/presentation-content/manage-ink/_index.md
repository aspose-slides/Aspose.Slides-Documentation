---
title: Tinte verwalten
type: docs
weight: 95
url: /python-net/manage-ink/
keywords: "Tinte in PowerPoint, Tintentools, Python Tinte, Zeichnen in PowerPoint, PowerPoint-Präsentation, Python, Aspose.Slides für Python über .NET"
description: "Verwenden Sie Tintentools, um Objekte in PowerPoint Python zu zeichnen"
---

PowerPoint bietet die Tintenfunktion, um nicht-standardisierte Figuren zu zeichnen, die verwendet werden können, um andere Objekte hervorzuheben, Verbindungen und Prozesse darzustellen und auf bestimmte Elemente auf einer Folie aufmerksam zu machen.

Aspose.Slides bietet das [Aspose.Slides.Ink](https://reference.aspose.com/slides/python-net/aspose.slides.ink/) Interface, das die Typen enthält, die Sie benötigen, um Tintenobjekte zu erstellen und zu verwalten.

## **Unterschiede zwischen regulären Objekten und Tintenobjekten**

Objekte auf einer PowerPoint-Folie werden typischerweise durch Formobjekte dargestellt. Ein Formobjekt ist in seiner einfachsten Form ein Container, der den Bereich des Objekts selbst (seinen Rahmen) sowie dessen Eigenschaften definiert. Letztere umfassen die Größe des Containerbereichs, die Form des Containers, den Hintergrund des Containers usw. Weitere Informationen finden Sie im Abschnitt [Form Layout Format](https://docs.aspose.com/slides/python-net/shape-manipulations/#access-layout-formats-for-shape).

Wenn PowerPoint jedoch mit einem Tintenobjekt arbeitet, ignoriert es alle Eigenschaften des Objektrahmens (Containers) außer seiner Größe. Die Größe des Containerbereichs wird durch die standardmäßigen `width` und `height` Werte bestimmt:

![ink_powerpoint1](ink_powerpoint1.png)

## **Tintenform Spuren**

Eine Spur ist ein grundlegendes Element oder Standard, der verwendet wird, um die Trajektorie eines Stifts aufzuzeichnen, während ein Benutzer digitale Tinte schreibt. Spuren sind Aufzeichnungen, die Sequenzen von verbundenen Punkten beschreiben.

Die einfachste Form der Kodierung gibt die X- und Y-Koordinaten jedes Stichpunkts an. Wenn alle verbundenen Punkte gerendert werden, erzeugen sie ein Bild wie dieses:

![ink_powerpoint2](ink_powerpoint2.png)

## Pinsel Eigenschaften zum Zeichnen

Sie können einen Pinsel verwenden, um Linien zu ziehen, die die Punkte von Spurenelementen verbinden. Der Pinsel hat seine eigene Farbe und Größe, die den Eigenschaften `Brush.Color` und `Brush.Size` entsprechen.

### **Tintenpinsel Farbe festlegen**

Dieser Python-Code zeigt, wie Sie die Farbe für einen Pinsel festlegen:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as pres:
    ink = pres.slides[0].shapes[0]
    traces = ink.traces
    brush = traces[0].brush
    brush_color = brush.color
    brush.color = draw.Color.red
```

### **Tintenpinsel Größe festlegen**

Dieser Python-Code zeigt, wie Sie die Größe für einen Pinsel festlegen:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as pres:
    ink = pres.slides[0].shapes[0]
    traces = ink.traces
    brush = traces[0].brush
    brush_size = brush.size
    brush.size = draw.SizeF(5.0, 10.0)
```

Im Allgemeinen stimmen die Breite und Höhe eines Pinsels nicht überein, sodass PowerPoint die Pinselgröße nicht anzeigt (der Datenbereich ist grau hinterlegt). Wenn jedoch die Breite und Höhe des Pinsels übereinstimmen, zeigt PowerPoint die Größe auf diese Weise an:

![ink_powerpoint3](ink_powerpoint3.png)

Um die Dinge zu verdeutlichen, lassen Sie uns die Höhe des Tintenobjekts erhöhen und die wichtigen Dimensionen überprüfen:

![ink_powerpoint4](ink_powerpoint4.png)

Der Container (Rahmen) berücksichtigt nicht die Größe der Pinsel – er geht immer davon aus, dass die Dicke der Linie null ist (siehe das letzte Bild).

Daher müssen wir zur Bestimmung des sichtbaren Bereichs des gesamten Tintenobjekts die Pinselgröße der Spurobjekte berücksichtigen. Hier wurde das Zielobjekt (das handschriftliche Textspurobjekt) auf die Größe des Containers (Rahmen) skaliert. Wenn sich die Größe des Containers (Rahmen) ändert, bleibt die Pinselgröße konstant und umgekehrt.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint zeigt dasselbe Verhalten bei der Verarbeitung von Texten:

![ink_powerpoint6](ink_powerpoint6.png)

**Weiterführende Informationen**

* Um mehr über Formen im Allgemeinen zu erfahren, siehe den Abschnitt [PowerPoint Formen](https://docs.aspose.com/slides/python-net/powerpoint-shapes/).
* Für weitere Informationen zu effektiven Werten siehe [Form Effektive Eigenschaften](https://docs.aspose.com/slides/python-net/shape-effective-properties/#get-effective-font-height-value).