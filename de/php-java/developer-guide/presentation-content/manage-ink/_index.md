---
title: Ink-Objekte in Präsentationen mit PHP verwalten
linktitle: Ink verwalten
type: docs
weight: 95
url: /de/php-java/manage-ink/
keywords:
- Tinte
- Ink-Objekt
- Ink-Spur
- Ink verwalten
- Ink zeichnen
- Zeichnung
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Verwalten Sie PowerPoint-Ink-Objekte — erstellen, bearbeiten & gestalten digitale Tinte mit Aspose.Slides für PHP via Java. Erhalten Sie Code-Beispiele für Spuren, Pinselfarbe & Größe."
---

PowerPoint bietet die Ink‑Funktion, mit der Sie nicht standardisierte Figuren zeichnen können, die verwendet werden, um andere Objekte hervorzuheben, Verbindungen und Prozesse darzustellen und die Aufmerksamkeit auf bestimmte Elemente einer Folie zu lenken. 

Aspose.Slides stellt alle Ink‑Typen (z. B. die Klasse [Ink](https://reference.aspose.com/slides/php-java/aspose.slides/ink/)) bereit, die Sie zum Erstellen und Verwalten von Ink‑Objekten benötigen.

## **Unterschiede zwischen regulären Objekten und Ink‑Objekten**

Objekte auf einer PowerPoint‑Folie werden typischerweise durch Shape‑Objekte dargestellt. Ein Shape‑Objekt ist in seiner einfachsten Form ein Container, der den Bereich des Objekts selbst (seinen Rahmen) zusammen mit seinen Eigenschaften definiert. Letzteres umfasst die Größe des Containerbereichs, die Form des Containers, den Hintergrund des Containers usw. Weitere Informationen finden Sie unter [Shape Layout Format](https://docs.aspose.com/slides/php-java/shape-manipulations/#access-layout-formats-for-shape).

Wenn PowerPoint jedoch mit einem Ink‑Objekt arbeitet, ignoriert es alle Eigenschaften des Objektrahmens (Containers) außer seiner Größe. Die Größe des Containerbereichs wird durch die Standardwerte `width` und `height` bestimmt:

![ink_powerpoint1](ink_powerpoint1.png)

## **Inkshape‑Spuren**

Ein Trace ist ein Basiselement oder Standard, das verwendet wird, um die Bahn eines Stiftes aufzuzeichnen, wenn ein Benutzer digitale Tinte schreibt. Traces sind Aufzeichnungen, die Sequenzen von verbundenen Punkten beschreiben. 

Die einfachste Form der Kodierung gibt die X‑ und Y‑Koordinaten jedes Abtastpunkts an. Wenn alle verbundenen Punkte gerendert werden, entsteht ein Bild wie dieses:

![ink_powerpoint2](ink_powerpoint2.png)

## **Pinsel‑Eigenschaften für das Zeichnen**

Sie können einen Pinsel verwenden, um Linien zu zeichnen, die die Punkte von Trace‑Elementen verbinden. Der Pinsel hat seine eigene Farbe und Größe, die den Eigenschaften `Brush.Color` und `Brush.Size` entsprechen. 

### **Ink‑Pinselfarbe festlegen**

Dieser PHP‑Code zeigt Ihnen, wie Sie die Farbe für einen Pinsel festlegen:
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


### **Ink‑Pinselgröße festlegen** 

Dieser PHP‑Code zeigt Ihnen, wie Sie die Größe für einen Pinsel festlegen:
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


Im Allgemeinen stimmen die Breite und Höhe eines Pinsels nicht überein, sodass PowerPoint die Pinselgröße nicht anzeigt (der Datenbereich ist ausgegraut). Stimmen jedoch Breite und Höhe des Pinsels überein, zeigt PowerPoint die Größe wie folgt an:

![ink_powerpoint3](ink_powerpoint3.png)

Zur Verdeutlichung erhöhen wir die Höhe des Ink‑Objekts und betrachten die wichtigen Abmessungen: 

![ink_powerpoint4](ink_powerpoint4.png)

Der Container (Rahmen) berücksichtigt die Größe der Pinsel nicht – er geht immer davon aus, dass die Linienstärke null ist (siehe das letzte Bild). 

Daher müssen wir zur Bestimmung des sichtbaren Bereichs des gesamten Ink‑Objekts die Pinselgröße der Trace‑Objekte berücksichtigen. Hier wurde das Zielobjekt (das Trace‑Objekt des handgeschriebenen Textes) auf die Größe des Containers (Rahmens) skaliert. Ändert sich die Größe des Containers (Rahmens), bleibt die Pinselgröße konstant und umgekehrt. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint zeigt dasselbe Verhalten beim Umgang mit Texten:

![ink_powerpoint6](ink_powerpoint6.png)

**Weiterführende Literatur**

* Um allgemeine Informationen zu Shapes zu erhalten, siehe den Abschnitt [PowerPoint Shapes](https://docs.aspose.com/slides/php-java/powerpoint-shapes/).
* Weitere Informationen zu effektiven Werten finden Sie unter [Shape Effective Properties](https://docs.aspose.com/slides/php-java/shape-effective-properties/#getting-effective-font-height-value).