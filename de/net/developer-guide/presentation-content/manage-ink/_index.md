---  
title: Tinte verwalten  
type: docs  
weight: 95  
url: /net/manage-ink/  
keywords: "Tinte in PowerPoint, Tintentools, C# Tinte, Zeichnen in PowerPoint, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET "  
description: "Verwenden Sie Tintentools, um Objekte in PowerPoint C# zu zeichnen"  
---  

PowerPoint bietet die Tintenfunktion, mit der Sie nicht standardmäßige Figuren zeichnen können, die verwendet werden können, um andere Objekte hervorzuheben, Verbindungen und Prozesse zu zeigen und die Aufmerksamkeit auf bestimmte Elemente auf einer Folie zu lenken.  

Aspose.Slides bietet das [Aspose.Slides.Ink](https://reference.aspose.com/slides/net/aspose.slides.ink/) Interface, das die Typen enthält, die Sie benötigen, um Tintenobjekte zu erstellen und zu verwalten.  

## **Unterschiede zwischen regulären Objekten und Tintenobjekten**  

Objekte auf einer PowerPoint-Folie werden typischerweise durch Formobjekte dargestellt. Ein Formobjekt ist in seiner einfachsten Form ein Container, der den Bereich des Objekts selbst (sein Rahmen) sowie dessen Eigenschaften definiert. Letztere umfasst die Größe des Containerbereichs, die Form des Containers, den Hintergrund des Containers usw. Weitere Informationen finden Sie im Abschnitt [Formate für die Anordnung](https://docs.aspose.com/slides/net/shape-manipulations/#access-layout-formats-for-shape).  

Wenn PowerPoint jedoch mit einem Tintenobjekt umgeht, ignoriert es alle Eigenschaften des Objektumfangs (Containers) außer seiner Größe. Die Größe des Containerbereichs wird durch die standardmäßigen Werte `width` und `height` bestimmt:  

![ink_powerpoint1](ink_powerpoint1.png)  

## **Tintenform-Spuren**  

Eine Spur ist ein grundlegendes Element oder ein Standard, der verwendet wird, um die Trajektorie eines Stifts aufzuzeichnen, während ein Benutzer digitale Tinte schreibt. Spuren sind Aufzeichnungen, die Sequenzen verbundener Punkte beschreiben.  

Die einfachste Form der Kodierung spezifiziert die X- und Y-Koordinaten jedes Abtastpunkts. Wenn alle verbundenen Punkte gerendert werden, erzeugen sie ein Bild wie dieses:  

![ink_powerpoint2](ink_powerpoint2.png)  

## Pinsel-Eigenschaften zum Zeichnen  

Sie können einen Pinsel verwenden, um Linien zu zeichnen, die die Punkte der Spurelemente verbinden. Der Pinsel hat seine eigene Farbe und Größe, die den Eigenschaften `Brush.Color` und `Brush.Size` entspricht.  

### **Tintenpinsel-Farbe festlegen**  

Dieser C#-Code zeigt Ihnen, wie Sie die Farbe für einen Pinsel festlegen:  

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

### **Tintenpinsel-Größe festlegen**  

Dieser C#-Code zeigt Ihnen, wie Sie die Größe für einen Pinsel festlegen:  

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

Im Allgemeinen stimmen Breite und Höhe eines Pinsels nicht überein, sodass PowerPoint die Pinselgröße nicht anzeigt (der Datenbereich ist ausgegraut). Wenn jedoch Breite und Höhe des Pinsels übereinstimmen, zeigt PowerPoint seine Größe auf diese Weise an:  

![ink_powerpoint3](ink_powerpoint3.png)  

Um Klarheit zu schaffen, lassen Sie uns die Höhe des Tintenobjekts erhöhen und die wichtigen Dimensionen überprüfen:  

![ink_powerpoint4](ink_powerpoint4.png)  

Der Container (Rahmen) berücksichtigt nicht die Größe der Pinsel - er geht immer davon aus, dass die Dicke der Linie null ist (siehe das letzte Bild).  

Um also den sichtbaren Bereich des gesamten Tintenobjekts zu bestimmen, müssen wir die Pinselgröße der Spurobjekte berücksichtigen. Hier wurde das Zielobjekt (das handschriftliche Textspurobjekt) auf die Größe des Containers (Rahmen) skaliert. Wenn sich die Größe des Containers (Rahmen) ändert, bleibt die Pinselgröße konstant und umgekehrt.  

![ink_powerpoint5](ink_powerpoint5.png)  

PowerPoint zeigt dasselbe Verhalten im Umgang mit Texten:  

![ink_powerpoint6](ink_powerpoint6.png)  

**Weiterführende Informationen**  

* Um allgemein über Formen zu lesen, siehe den Abschnitt [PowerPoint Formen](https://docs.aspose.com/slides/net/powerpoint-shapes/).  
* Für weitere Informationen zu effektiven Werten siehe [Effektive Eigenschaften von Formen](https://docs.aspose.com/slides/net/shape-effective-properties/#get-effective-font-height-value).  