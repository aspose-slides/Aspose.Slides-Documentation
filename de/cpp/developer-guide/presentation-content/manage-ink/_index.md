---
title: Tinte verwalten
type: docs
weight: 95
url: /de/cpp/manage-ink/
keywords: "Tinte in PowerPoint, Tintenwerkzeuge, C++ Tinte, Zeichnen in PowerPoint, PowerPoint-Präsentation, C++, CPP, Aspose.Slides für C++"
description: "Verwenden Sie Tintenwerkzeuge, um Objekte in PowerPoint C++ zu zeichnen"
---

PowerPoint bietet die Tintenfunktion, die es Ihnen ermöglicht, nicht standardmäßige Figuren zu zeichnen, die verwendet werden können, um andere Objekte hervorzuheben, Verbindungen und Prozesse darzustellen und auf spezifische Elemente in einer Folie aufmerksam zu machen.

Aspose.Slides bietet die [Aspose.Slides.Ink](https://reference.aspose.com/slides/cpp/aspose.slides.ink/) Schnittstelle, die die Typen enthält, die Sie benötigen, um Tintenobjekte zu erstellen und zu verwalten.

## **Unterschiede zwischen regulären Objekten und Tintenobjekten**

Objekte auf einer PowerPoint-Folie werden typischerweise durch Formobjekte dargestellt. Ein Formobjekt ist in seiner einfachsten Form ein Container, der den Bereich des Objekts selbst (seinen Rahmen) zusammen mit seinen Eigenschaften definiert. Letztere umfasst die Größe des Containerbereichs, die Form des Containers, den Hintergrund des Containers usw. Weitere Informationen finden Sie im Abschnitt [Formate für das Layout von Formen](https://docs.aspose.com/slides/cpp/shape-manipulations/#access-layout-formats-for-shape).

Wenn PowerPoint jedoch mit einem Tintenobjekt zu tun hat, ignoriert es alle Eigenschaften des Objektrahmens (Containers) außer dessen Größe. Die Größe des Containerbereichs wird durch die Standardwerte `width` und `height` bestimmt:

![ink_powerpoint1](ink_powerpoint1.png)

## **Tintenpfade**

Ein Pfad ist ein Element oder Standard, der verwendet wird, um die Bewegung eines Stiftes aufzuzeichnen, während ein Benutzer digitale Tinte schreibt. Pfade sind Aufzeichnungen, die Sequenzen verbundener Punkte beschreiben.

Die einfachste Form der Codierung gibt die X- und Y-Koordinaten jedes Stichpunkts an. Wenn alle verbundenen Punkte wiedergegeben werden, ergeben sie ein Bild wie dieses:

![ink_powerpoint2](ink_powerpoint2.png)

## Bürsteneigenschaften zum Zeichnen

Sie können einen Pinsel verwenden, um Linien zu zeichnen, die die Punkte der Pfad-Elemente verbinden. Der Pinsel hat seine eigene Farbe und Größe, die den Eigenschaften `Brush.Color` und `Brush.Size` entsprechen.

### **Tintenbürstenfarbe festlegen**

Dieser C++-Code zeigt Ihnen, wie Sie die Farbe für einen Pinsel festlegen:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<IInk> ink = System::ExplicitCast<IInk>(pres->get_Slide(0)->get_Shape(0));
System::ArrayPtr<System::SharedPtr<IInkTrace>> traces = ink->get_Traces();
System::SharedPtr<IInkBrush> brush = traces[0]->get_Brush();
System::Drawing::Color brushColor = brush->get_Color();
brush->set_Color(System::Drawing::Color::get_Red());
```

### **Tintenbürstengröße festlegen**

Dieser C++-Code zeigt Ihnen, wie Sie die Größe für einen Pinsel festlegen:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<IInk> ink = System::ExplicitCast<IInk>(pres->get_Slide(0)->get_Shape(0));
System::ArrayPtr<System::SharedPtr<IInkTrace>> traces = ink->get_Traces();
System::SharedPtr<IInkBrush> brush = traces[0]->get_Brush();
System::Drawing::SizeF brushSize = brush->get_Size();
brush->set_Size(System::Drawing::SizeF(5.0f, 10.0f));
```

Im Allgemeinen stimmen die Breite und Höhe eines Pinsels nicht überein, sodass PowerPoint die Pinselgröße nicht anzeigt (der Datensatz ist grau hinterlegt). Wenn jedoch die Breite und Höhe des Pinsels übereinstimmen, zeigt PowerPoint seine Größe auf folgende Weise an:

![ink_powerpoint3](ink_powerpoint3.png)

Zur Verdeutlichung erhöhen wir die Höhe des Tintenobjekts und überprüfen die wichtigen Dimensionen:

![ink_powerpoint4](ink_powerpoint4.png)

Der Container (Rahmen) berücksichtigt nicht die Größe der Pinsel – er geht immer davon aus, dass die Linienstärke null ist (siehe das letzte Bild).

Um daher den sichtbaren Bereich des gesamten Tintenobjekts zu bestimmen, müssen wir die Pinselgröße der Trace-Objekte berücksichtigen. Hier wurde das Zielobjekt (das handschriftliche Text-Trace-Objekt) auf die Größe des Containers (Rahmen) skaliert. Wenn sich die Größe des Containers (Rahmen) ändert, bleibt die Pinselgröße konstant und umgekehrt.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint zeigt dasselbe Verhalten beim Umgang mit Texten:

![ink_powerpoint6](ink_powerpoint6.png)

**Weiterführende Informationen**

* Um mehr über Formen im Allgemeinen zu erfahren, siehe den Abschnitt [PowerPoint Formen](https://docs.aspose.com/slides/cpp/powerpoint-shapes/).
* Weitere Informationen zu effektiven Werten finden Sie unter [Effektive Eigenschaften von Formen](https://docs.aspose.com/slides/cpp/shape-effective-properties/#get-effective-font-height-value).