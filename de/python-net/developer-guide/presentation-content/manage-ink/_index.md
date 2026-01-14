---
title: Verwalten von Ink-Objekten in Präsentationen mit Python
linktitle: Ink verwalten
type: docs
weight: 95
url: /de/python-net/manage-ink/
keywords:
- Tinte
- Ink-Objekt
- Ink-Spur
- Ink verwalten
- Ink zeichnen
- Zeichnung
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Verwalten Sie PowerPoint-Ink-Objekte - erstellen, bearbeiten & stylen digitale Tinte mit Aspose.Slides für Python via .NET. Erhalten Sie Codebeispiele für Spuren, Pinsel-Farbe & Größe."
---

PowerPoint stellt die Ink-Funktion bereit, mit der Sie nicht-standardisierte Figuren zeichnen können, die zum Hervorheben anderer Objekte, zum Anzeigen von Verbindungen und Prozessen sowie zum Aufmerksam-machen auf bestimmte Elemente einer Folie verwendet werden können. 

Aspose.Slides stellt den Namespace [aspose.slides.ink](https://reference.aspose.com/slides/python-net/aspose.slides.ink/) bereit, der die Typen enthält, die Sie zum Erstellen und Verwalten von Ink-Objekten benötigen. 

## **Unterschiede zwischen regulären Objekten und Ink-Objekten**

Objekte auf einer PowerPoint-Folien werden typischerweise durch Shape-Objekte dargestellt. Ein Shape-Objekt ist in seiner einfachsten Form ein Container, der den Bereich des Objekts selbst (seinen Rahmen) zusammen mit seinen Eigenschaften definiert. Letztere umfassen die Größe des Containerbereichs, die Form des Containers, den Hintergrund des Containers usw. Weitere Informationen finden Sie unter [Shape Layout Format](https://docs.aspose.com/slides/python-net/shape-manipulations/#access-layout-formats-for-shape).

Wenn PowerPoint jedoch mit einem Ink-Objekt arbeitet, ignoriert es alle Eigenschaften des Objekt-Frames (Containers) außer seiner Größe. Die Größe des Container-Bereichs wird durch die Standardwerte `width` und `height` bestimmt:

![ink_powerpoint1](ink_powerpoint1.png)

## **Inkshape-Spuren**

Eine Spur ist ein Basiselement oder ein Standard, der verwendet wird, um die Bahn eines Stifts aufzuzeichnen, während ein Benutzer digitale Tinte schreibt. Spuren sind Aufnahmen, die Sequenzen verbundener Punkte beschreiben. 

Die einfachste Form der Kodierung gibt die X- und Y-Koordinaten jedes Stichprobenpunkts an. Wenn alle verbundenen Punkte gerendert werden, entsteht ein Bild wie dieses:

![ink_powerpoint2](ink_powerpoint2.png)

## Pinsel-Eigenschaften zum Zeichnen 

Sie können einen Pinsel verwenden, um Linien zu zeichnen, die die Punkte von Spur-Elementen verbinden. Der Pinsel besitzt seine eigene Farbe und Größe, die den Eigenschaften `Brush.color` und `Brush.size` entsprechen. 

### **Ink-Pinselfarbe festlegen**

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


### **Ink-Pinselgröße festlegen** 

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


In der Regel stimmen Breite und Höhe eines Pinsels nicht überein, sodass PowerPoint die Pinselgröße nicht anzeigt (der Datenbereich ist ausgegraut). Stimmen Breite und Höhe des Pinsels jedoch überein, zeigt PowerPoint die Größe wie folgt an:

![ink_powerpoint3](ink_powerpoint3.png)

Zur Veranschaulichung erhöhen wir die Höhe des Ink-Objekts und betrachten die wichtigen Abmessungen: 

![ink_powerpoint4](ink_powerpoint4.png)

Der Container (Frame) berücksichtigt die Größe der Pinsel nicht - er geht stets davon aus, dass die Linienstärke null ist (siehe das letzte Bild). 

Daher müssen wir, um den sichtbaren Bereich des gesamten Ink-Objekts zu bestimmen, die Pinselgröße der Spur-Objekte berücksichtigen. Hier wurde das Zielobjekt (das Spur-Objekt für handgeschriebenen Text) auf die Größe des Containers (Frames) skaliert. Ändert sich die Größe des Containers (Frames), bleibt die Pinselgröße konstant und umgekehrt. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint zeigt das gleiche Verhalten bei Texten:

![ink_powerpoint6](ink_powerpoint6.png)

**Weitere Informationen**

* Um allgemeine Informationen zu Shapes zu erhalten, siehe den Abschnitt [PowerPoint Shapes](https://docs.aspose.com/slides/python-net/powerpoint-shapes/). 
* Weitere Informationen zu effektiven Werten finden Sie unter [Shape Effective Properties](https://docs.aspose.com/slides/python-net/shape-effective-properties/#get-effective-font-height-value).