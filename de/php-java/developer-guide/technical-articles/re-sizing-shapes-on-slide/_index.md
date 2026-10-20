---
title: Formen auf Präsentationsfolien in PHP skalieren
type: docs
weight: 130
url: /de/php-java/resizing-shapes-on-slide/
aliases:
  - /php-java/re-sizing-shapes-on-slide/
  - /de/php-java/re-sizing-shapes-on-slide/
keywords:
- Formgröße ändern
- Größe der Form ändern
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Einfach Formen auf PowerPoint- und OpenDocument-Folien mit Aspose.Slides für PHP via Java skalieren - Folienlayout-Anpassungen automatisieren und die Produktivität steigern."
---
## **Übersicht**

Wenn Sie die Foliengröße einer Präsentation ändern, müssen Sie möglicherweise auch die Formen skalieren und neu positionieren, damit sie zu den neuen Abmessungen passen. Dieser Artikel zeigt, wie Sie Formen manuell skalieren und wie Sie Tabellen auf Folien, Masterfolien und Layouts behandeln.

## **Formen skalieren**

Um die relative Position und Größe jeder Form beizubehalten, multiplizieren Sie ihre horizontalen Koordinaten und Breite mit dem Verhältnis der neuen Folienbreite zur ursprünglichen Breite. Wenden Sie das entsprechende Höhenverhältnis auf die vertikalen Koordinaten und die Höhe an.

Das erste Beispiel lädt eine Präsentation, deren Folien keine Tabellen enthalten, ändert die Foliengröße zu A4 und speichert das Ergebnis. Es verwendet [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/) mit [SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/php-java/aspose.slides/slidesizescaletype/) sodass die nachfolgende Schleife die Skalierung steuert. Die Verhältnisse sind einheitenlos; Formpositionen und -abmessungen werden in Punkten gemessen. Unterschiedliche Breiten- und Höhenverhältnisse können Formen verzerren, und das Ändern der Formabmessungen skaliert die Schriftgrößen nicht.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SlideSizeType;

$presentation = new Presentation("sample.pptx");
try {
    // Unabhängige horizontale und vertikale Skalierungsfaktoren berechnen.
    $originalSize = $presentation->getSlideSize()->getSize();
    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
    $targetSize = $presentation->getSlideSize()->getSize();
    $widthRatio = java_values($targetSize->getWidth()) / java_values($originalSize->getWidth());
    $heightRatio = java_values($targetSize->getHeight()) / java_values($originalSize->getHeight());

    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            $shape->setWidth(java_values($shape->getWidth()) * $widthRatio);
            $shape->setHeight(java_values($shape->getHeight()) * $heightRatio);
            $shape->setX(java_values($shape->getX()) * $widthRatio);
            $shape->setY(java_values($shape->getY()) * $heightRatio);
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Tabellen erfordern eine separate Behandlung: Skalieren Sie ihre Spaltenbreiten und Zeilenhöhen, anstatt die Gesamtabmessungen der Tabelle festzulegen. Zeilenhöhen können größer bleiben als angefordert, wenn der Zellinhalt mehr Platz benötigt.
{{% /alert %}}

Das zweite Beispiel unterstützt Tabellen und verarbeitet Formen auf Masterfolien und Layouts sowie einzelne Folien, bevor die skalierte Präsentation gespeichert wird. Sein Helfer verarbeitet jede [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) indem er die Spaltenbreiten mit [Column::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/column/setwidth/) und die minimalen Zeilenhöhen mit [Row::setMinimalHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/setminimalheight/) skaliert. Anschließend wird die Position der Tabelle skaliert, ohne ihre Gesamtabmessungen separat zu skalieren.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SlideSizeType;

class ShapeResizer {
    public function resizeShapes($shapes, $widthRatio, $heightRatio) {
        $tableClass = new JavaClass("com.aspose.slides.Table");
        for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
            $shape = $shapes->get_Item($shapeIndex);
            if (java_instanceof($shape, $tableClass)) {
                $table = $shape;
                // Tabellendimensionen werden durch Spaltenbreiten und Zeilenhöhen gesteuert.
                for ($columnIndex = 0; $columnIndex < java_values($table->getColumns()->size()); $columnIndex++) {
                    $column = $table->getColumns()->get_Item($columnIndex);
                    $column->setWidth(java_values($column->getWidth()) * $widthRatio);
                }

                for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
                    $row = $table->getRows()->get_Item($rowIndex);
                    $row->setMinimalHeight(java_values($row->getMinimalHeight()) * $heightRatio);
                }
            }
            else {
                $shape->setWidth(java_values($shape->getWidth()) * $widthRatio);
                $shape->setHeight(java_values($shape->getHeight()) * $heightRatio);
            }

            $shape->setX(java_values($shape->getX()) * $widthRatio);
            $shape->setY(java_values($shape->getY()) * $heightRatio);
        }
    }
}

$presentation = new Presentation("sample.pptx");
try {
    // Unabhängige horizontale und vertikale Skalierungsfaktoren berechnen.
    $originalSize = $presentation->getSlideSize()->getSize();
    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
    $targetSize = $presentation->getSlideSize()->getSize();
    $widthRatio = java_values($targetSize->getWidth()) / java_values($originalSize->getWidth());
    $heightRatio = java_values($targetSize->getHeight()) / java_values($originalSize->getHeight());

    $resizer = new ShapeResizer();

    // Formen skalieren, die auf Masterfolien und Layouts sowie auf einzelnen Folien definiert sind.
    for ($masterIndex = 0; $masterIndex < java_values($presentation->getMasters()->size()); $masterIndex++) {
        $master = $presentation->getMasters()->get_Item($masterIndex);
        $resizer->resizeShapes($master->getShapes(), $widthRatio, $heightRatio);

        for ($layoutSlideIndex = 0; $layoutSlideIndex < java_values($master->getLayoutSlides()->size()); $layoutSlideIndex++) {
            $layoutSlide = $master->getLayoutSlides()->get_Item($layoutSlideIndex);
            $resizer->resizeShapes($layoutSlide->getShapes(), $widthRatio, $heightRatio);
        }
    }

    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $resizer->resizeShapes($slide->getShapes(), $widthRatio, $heightRatio);
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

## **FAQ**

**Warum sind Formen nach dem Ändern der Foliengröße verzerrt oder abgeschnitten?**

Wenn Sie die Foliengröße ändern, ohne die Formen zu skalieren, behalten sie ihre ursprünglichen Positionen und Abmessungen bei und können über die Folie hinausragen. Das Skalieren von Breite und Höhe mit unterschiedlichen Verhältnissen kann ebenfalls Formen verzerren.

**Funktioniert der bereitgestellte Code für alle Formtypen?**

Das erste Beispiel ändert die Formgrenzen direkt und ist für Folien ohne Tabellen gedacht. Das zweite Beispiel behandelt Tabellen separat. Überprüfen Sie das resultierende Layout, insbesondere Text und Tabellen, da diese Beispiele die Schriftgrößen nicht skalieren und der Tabelleninhalt die Zeilenhöhen einschränken kann.

**Wie kann ich Tabellen beim Ändern der Foliengröße skalieren?**

Skalieren Sie die Spaltenbreiten anhand des Breitenverhältnisses und die minimalen Zeilenhöhen anhand des Höhenverhältnisses, und skalieren Sie anschließend die Position der Tabelle, wie im zweiten Beispiel gezeigt.

**Funktioniert dieses Skalieren für Masterfolien und Layoutfolien?**

Ja. Das zweite Beispiel iteriert über [Presentation::getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getmasters/) und über die [MasterSlide::getLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/getlayoutslides/) jedes Masters und wendet dieselbe Skalierungslogik auf deren Formen an.

**Kann ich die Ausrichtung einer Folie (Portrait/Landscape) zusammen mit der Skalierung ändern?**

Ja. Rufen Sie [SlideSize::setOrientation](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setorientation/) nach dem Ändern der Foliengröße und vor dem Auslesen der Zielabmessungen auf, sodass die Skalierungsfaktoren die endgültige Ausrichtung berücksichtigen.

**Gibt es eine Grenze für die Foliengröße, die ich festlegen kann?**

Sie können benutzerdefinierte Folienmaße mit [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/) angeben. Die unterstützten Maße hängen außerdem vom Präsentationsformat und von der Anwendung ab, die die Datei öffnet.

**Wie kann ich verhindern, dass Formen mit festem Seitenverhältnis verzerrt werden?**

Verwenden Sie denselben Skalierungsfaktor für Breite und Höhe. Um das ursprüngliche Layout in die neuen Folienabmessungen einzupassen, verwenden Sie das kleinere der beiden Verhältnisse für beide Dimensionen und Positionen. Dadurch bleiben die Proportionen erhalten, es kann jedoch entlang einer Kante ungenutzter Raum verbleiben.