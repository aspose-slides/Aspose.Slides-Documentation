---
title: Tinte verwalten
type: docs
weight: 95
url: /php-java/manage-ink/
keywords: "Tinte in PowerPoint, Tintenwerkzeuge, Java Tinte, Zeichnen in PowerPoint, PowerPoint-Präsentation, Java, Aspose.Slides für PHP über Java"
description: "Verwenden Sie Tintenwerkzeuge, um Objekte in PowerPoint Java zu zeichnen"
---

PowerPoint bietet die Tintenfunktion, mit der Sie nicht-standardisierte Figuren zeichnen können, die verwendet werden können, um andere Objekte hervorzuheben, Verbindungen und Prozesse darzustellen und die Aufmerksamkeit auf bestimmte Elemente in einer Folie zu lenken.

Aspose.Slides bietet alle benötigten Tintenarten (z. B. [Ink](https://reference.aspose.com/slides/php-java/aspose.slides/ink/) Klasse), um Tintenobjekte zu erstellen und zu verwalten.

## **Unterschiede zwischen regulären Objekten und Tintenobjekten**

Objekte auf einer PowerPoint-Folie werden typischerweise durch Formobjekte dargestellt. Ein Formobjekt ist in seiner einfachsten Form ein Container, der den Bereich des Objekts selbst (seinen Rahmen) neben seinen Eigenschaften definiert. Letztere umfassen die Größe des Containerbereichs, die Form des Containers, den Hintergrund des Containers usw. Für Informationen siehe [Shape Layout Format](https://docs.aspose.com/slides/php-java/shape-manipulations/#access-layout-formats-for-shape).

Wenn PowerPoint jedoch mit einem Tintenobjekt zu tun hat, ignoriert es alle Eigenschaften des Objektrahmens (Containers) außer seiner Größe. Die Größe des Containerbereichs wird durch die Standardwerte `width` und `height` bestimmt:

![ink_powerpoint1](ink_powerpoint1.png)

## **Tintenstriche**

Ein Strich ist ein Grundelement oder Standard, der verwendet wird, um die Trajektorie eines Stiftes aufzuzeichnen, während ein Benutzer digitale Tinte schreibt. Striche sind Aufzeichnungen, die eine Sequenz von verbundenen Punkten beschreiben.

Die einfachste Form der Kodierung gibt die X- und Y-Koordinaten jedes Probenpunkts an. Wenn alle verbundenen Punkte gerendert werden, erzeugen sie ein Bild wie dieses:

![ink_powerpoint2](ink_powerpoint2.png)

## Pinsel Eigenschaften zum Zeichnen

Sie können einen Pinsel verwenden, um Linien zu ziehen, die die Punkte von Strichelementen verbinden. Der Pinsel hat seine eigene Farbe und Größe, die den Eigenschaften `Brush.Color` und `Brush.Size` entsprechen.

### **Tintenpinsel-Farbe festlegen**

Dieser PHP-Code zeigt Ihnen, wie Sie die Farbe für einen Pinsel festlegen:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $ink = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $traces = $ink->getTraces();
    $brush = $traces[0]->getBrush();
    $brushColor = $brush->getColor();
    $brush->setColor(java("java.awt.Color")->RED);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Tintenpinsel-Größe festlegen**

Dieser PHP-Code zeigt Ihnen, wie Sie die Größe für einen Pinsel festlegen:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $ink = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $traces = $ink->getTraces();
    $brush = $traces[0]->getBrush();
    $brushSize = $brush->getSize();
    $brush->setSize(new Java("java.awt.Dimension", 5, 10));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Generell stimmen die Breite und Höhe eines Pinsels nicht überein, sodass PowerPoint die Pinselgröße nicht anzeigt (der Datenbereich ist ausgegraut). Wenn jedoch die Breite und Höhe des Pinsels übereinstimmen, zeigt PowerPoint seine Größe so an:

![ink_powerpoint3](ink_powerpoint3.png)

Zur Verdeutlichung erhöhen wir die Höhe des Tintenobjekts und überprüfen die wichtigsten Abmessungen:

![ink_powerpoint4](ink_powerpoint4.png)

Der Container (Rahmen) berücksichtigt nicht die Größe der Pinsel – er geht immer davon aus, dass die Dicke der Linie null ist (siehe das letzte Bild).

Um daher den sichtbaren Bereich des gesamten Tintenobjekts zu bestimmen, müssen wir die Pinselgröße der Strichobjekte berücksichtigen. Hier wurde das Zielobjekt (das handgeschriebene Textstrichobjekt) auf die Größe des Containers (Rahmens) skaliert. Wenn sich die Größe des Containers (Rahmens) ändert, bleibt die Pinselgröße konstant und umgekehrt.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint zeigt dasselbe Verhalten im Umgang mit Texten:

![ink_powerpoint6](ink_powerpoint6.png)

**Weiterführende Informationen**

* Um mehr über Formen im Allgemeinen zu erfahren, siehe den Abschnitt [PowerPoint Shapes](https://docs.aspose.com/slides/php-java/powerpoint-shapes/).
* Für weitere Informationen zu effektiven Werten siehe [Shape Effective Properties](https://docs.aspose.com/slides/php-java/shape-effective-properties/#getting-effective-font-height-value).