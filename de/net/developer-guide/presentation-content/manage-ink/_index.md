---
title: Verwalten von Präsentations-Ink-Objekten in .NET
linktitle: Ink verwalten
type: docs
weight: 95
url: /de/net/manage-ink/
keywords:
- Ink
- Ink-Objekt
- Ink-Spur
- Ink verwalten
- Ink zeichnen
- Zeichnung
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Verwalten Sie PowerPoint‑Ink‑Objekte—Erstellen, Bearbeiten und Gestalten digitaler Tinte mit Aspose.Slides für .NET. Holen Sie Codebeispiele für Spuren, Pinsel‑Farbe und -Größe."
---

PowerPoint bietet die Ink‑Funktion, mit der Sie nicht standardmäßige Figuren zeichnen können, die verwendet werden, um andere Objekte hervorzuheben, Verbindungen und Prozesse darzustellen und die Aufmerksamkeit auf bestimmte Elemente einer Folie zu lenken. 

Aspose.Slides stellt die [Aspose.Slides.Ink](https://reference.aspose.com/slides/net/aspose.slides.ink/) Schnittstelle bereit, die die Typen enthält, die Sie benötigen, um Ink‑Objekte zu erstellen und zu verwalten. 

## **Unterschiede zwischen regulären Objekten und Ink‑Objekten**

Objekte auf einer PowerPoint‑Folien werden typischerweise durch Shape‑Objekte dargestellt. Ein Shape‑Objekt ist in seiner einfachsten Form ein Container, der den Bereich des Objekts selbst (seinen Rahmen) zusammen mit seinen Eigenschaften definiert. Letztere umfassen die Größe des Containerbereichs, die Form des Containers, den Hintergrund des Containers usw. Weitere Informationen finden Sie unter [Shape Layout Format](https://docs.aspose.com/slides/net/shape-manipulations/#access-layout-formats-for-shape).

Wenn PowerPoint jedoch mit einem Ink‑Objekt arbeitet, ignoriert es alle Eigenschaften des Objekt‑Frames (Containers) außer seiner Größe. Die Größe des Containerbereichs wird durch die Standardwerte `width` und `height` bestimmt:

![ink_powerpoint1](ink_powerpoint1.png)

## **Inkshape‑Spuren**

Eine Trace ist ein Basiselement oder ein Standard, der verwendet wird, um die Flugbahn einer Feder aufzuzeichnen, wenn ein Benutzer digitale Tinte schreibt. Traces sind Aufzeichnungen, die Sequenzen verbundener Punkte beschreiben. 

Die einfachste Form der Kodierung gibt die X‑ und Y‑Koordinaten jedes Messpunktes an. Wenn alle verbundenen Punkte gerendert werden, entsteht ein Bild wie dieses:

![ink_powerpoint2](ink_powerpoint2.png)

## **Pinsel‑Eigenschaften für das Zeichnen**

Sie können einen Pinsel verwenden, um Linien zu zeichnen, die die Punkte von Trace‑Elementen verbinden. Der Pinsel verfügt über seine eigene Farbe und Größe, die den Eigenschaften `Brush.Color` und `Brush.Size` entsprechen. 

### **Ink‑Pinselfarbe festlegen**

Der folgende C#‑Code zeigt, wie Sie die Farbe für einen Pinsel festlegen:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    IInk ink = (IInk)pres.Slides[0].Shapes[0];
    IInkTrace[] traces = ink.Traces;
    IInkBrush brush = traces[0].Brush;
    Color brushColor = brush.Color;
    brush.Color = Color.Red;
}
```


### **Ink‑Pinselgröße festlegen**

Der folgende C#‑Code zeigt, wie Sie die Größe für einen Pinsel festlegen:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    IInk ink = (IInk)pres.Slides[0].Shapes[0];
    IInkTrace[] traces = ink.Traces;
    IInkBrush brush = traces[0].Brush;
    SizeF brushSize = brush.Size;
    brush.Size = new SizeF(5f, 10f);
}
```


In der Regel stimmen Breite und Höhe eines Pinsels nicht überein, sodass PowerPoint die Pinselgröße nicht anzeigt (der Datenbereich ist ausgegraut). Stimmen jedoch Breite und Höhe des Pinsels überein, zeigt PowerPoint die Größe wie folgt an:

![ink_powerpoint3](ink_powerpoint3.png)

Zur Verdeutlichung erhöhen wir die Höhe des Ink‑Objekts und betrachten die wichtigen Abmessungen: 

![ink_powerpoint4](ink_powerpoint4.png)

Der Container (Rahmen) berücksichtigt die Größe der Pinsel nicht – er geht stets davon aus, dass die Linienstärke null ist (siehe das letzte Bild). 

Daher müssen wir zur Bestimmung des sichtbaren Bereichs des gesamten Ink‑Objekts die Pinselgröße der Trace‑Objekte berücksichtigen. Hier wurde das Zielobjekt (das Trace‑Objekt des handschriftlichen Textes) auf die Größe des Containers (Rahmens) skaliert. Ändert sich die Größe des Containers (Rahmens), bleibt die Pinselgröße konstant und umgekehrt. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint zeigt dasselbe Verhalten beim Umgang mit Texten:

![ink_powerpoint6](ink_powerpoint6.png)

**Weiterführende Lektüre**

* Um allgemeine Informationen zu Shapes zu erhalten, siehe den Abschnitt [PowerPoint Shapes](https://docs.aspose.com/slides/net/powerpoint-shapes/). 
* Weitere Informationen zu effektiven Werten finden Sie unter [Shape Effective Properties](https://docs.aspose.com/slides/net/shape-effective-properties/#get-effective-font-height-value).