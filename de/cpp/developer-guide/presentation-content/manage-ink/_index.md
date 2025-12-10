---
title: Verwalten von Präsentations-Ink-Objekten in C++
linktitle: Ink verwalten
type: docs
weight: 95
url: /de/cpp/manage-ink/
keywords:
- Tinte
- Tintenobjekt
- Ink-Spur
- Ink verwalten
- Ink zeichnen
- Zeichnen
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Verwalten Sie PowerPoint-Ink-Objekte – erstellen, bearbeiten und formatieren Sie digitale Tinte mit Aspose.Slides für C++. Erhalten Sie Codebeispiele für Spuren, Pinselfarbe und -größe."
---

PowerPoint bietet die Ink‑Funktion, mit der Sie nicht‑standardmäßige Figuren zeichnen können. Diese lassen sich verwenden, um andere Objekte hervorzuheben, Verbindungen und Prozesse darzustellen und die Aufmerksamkeit auf bestimmte Elemente einer Folie zu lenken. 

Aspose.Slides stellt das [Aspose.Slides.Ink](https://reference.aspose.com/slides/cpp/aspose.slides.ink/) Interface bereit, das die Typen enthält, die Sie zum Erstellen und Verwalten von Ink‑Objekten benötigen. 

## **Unterschiede zwischen regulären Objekten und Ink‑Objekten**

Objekte auf einer PowerPoint‑Folie werden typischerweise durch Shape‑Objekte repräsentiert. Ein Shape‑Objekt ist in seiner einfachsten Form ein Container, der den Bereich des Objekts selbst (seinen Rahmen) zusammen mit seinen Eigenschaften definiert. Letztere umfassen die Größe des Container‑Bereichs, die Form des Containers, den Hintergrund des Containers usw. Weitere Informationen finden Sie unter [Shape Layout Format](https://docs.aspose.com/slides/cpp/shape-manipulations/#access-layout-formats-for-shape).

Bei Ink‑Objekten hingegen ignoriert PowerPoint alle Eigenschaften des Objekt‑Rahmens (Containers) außer seiner Größe. Die Größe des Container‑Bereichs wird durch die Standardwerte `width` und `height` bestimmt:

![ink_powerpoint1](ink_powerpoint1.png)

## **Inkshape‑Spuren**

Eine Trace ist ein Basiselement bzw. ein Standard, mit dem die Flugbahn eines Stifts aufgezeichnet wird, während ein Benutzer digitale Tinte schreibt. Traces sind Aufnahmen, die Sequenzen von verbundenen Punkten beschreiben. 

Die einfachste Kodierungsform gibt die X‑ und Y‑Koordinaten jedes Sample‑Punkts an. Wenn alle verbundenen Punkte gerendert werden, entsteht ein Bild wie dieses:

![ink_powerpoint2](ink_powerpoint2.png)

## **Pinsel‑Eigenschaften zum Zeichnen**

Sie können einen Pinsel verwenden, um Linien zu zeichnen, die die Punkte von Trace‑Elementen verbinden. Der Pinsel hat seine eigene Farbe und Größe, die den Eigenschaften `Brush.Color` und `Brush.Size` entsprechen. 

### **Ink-Pinselfarbe festlegen**

Dieser C++‑Code zeigt, wie Sie die Farbe für einen Pinsel festlegen:
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<IInk> ink = System::ExplicitCast<IInk>(pres->get_Slide(0)->get_Shape(0));
System::ArrayPtr<System::SharedPtr<IInkTrace>> traces = ink->get_Traces();
System::SharedPtr<IInkBrush> brush = traces[0]->get_Brush();
System::Drawing::Color brushColor = brush->get_Color();
brush->set_Color(System::Drawing::Color::get_Red());
```


### **Ink-Pinselgröße festlegen** 

Dieser C++‑Code zeigt, wie Sie die Größe für einen Pinsel festlegen:
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<IInk> ink = System::ExplicitCast<IInk>(pres->get_Slide(0)->get_Shape(0));
System::ArrayPtr<System::SharedPtr<IInkTrace>> traces = ink->get_Traces();
System::SharedPtr<IInkBrush> brush = traces[0]->get_Brush();
System::Drawing::SizeF brushSize = brush->get_Size();
brush->set_Size(System::Drawing::SizeF(5.0f, 10.0f));
```


In der Regel stimmen Breite und Höhe eines Pinsels nicht überein, sodass PowerPoint die Pinselgröße nicht anzeigt (der Datenbereich ist ausgegraut). Stimmen Breite und Höhe jedoch überein, zeigt PowerPoint die Größe wie folgt an:

![ink_powerpoint3](ink_powerpoint3.png)

Zur Verdeutlichung erhöhen wir die Höhe des Ink‑Objekts und betrachten die wichtigen Abmessungen: 

![ink_powerpoint4](ink_powerpoint4.png)

Der Container (Rahmen) berücksichtigt die Größe der Pinsel nicht – er geht stets davon aus, dass die Linienstärke null ist (siehe letztes Bild). 

Daher müssen wir zur Bestimmung des sichtbaren Bereichs des gesamten Ink‑Objekts die Pinselgröße der Trace‑Objekte berücksichtigen. Hier wurde das Zielobjekt (die handgeschriebene Text‑Trace) auf die Container‑(Rahmen‑)Größe skaliert. Ändert sich die Größe des Containers (Rahmens), bleibt die Pinselgröße konstant und umgekehrt. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint zeigt dasselbe Verhalten bei Texten:

![ink_powerpoint6](ink_powerpoint6.png)

**Weiterführende Lektüre**

* Für allgemeine Informationen zu Shapes siehe den Abschnitt [PowerPoint Shapes](https://docs.aspose.com/slides/cpp/powerpoint-shapes/). 
* Weitere Details zu effektiven Werten finden Sie unter [Shape Effective Properties](https://docs.aspose.com/slides/cpp/shape-effective-properties/#get-effective-font-height-value).