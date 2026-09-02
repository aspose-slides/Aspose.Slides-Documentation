---
title: Verwalten von Präsentationsplatzhaltern in PHP
linktitle: Platzhalter verwalten
type: docs
weight: 10
url: /de/php-java/manage-placeholder/
keywords:
- Platzhalter
- Textplatzhalter
- Bildplatzhalter
- Diagrammplatzhalter
- Inhaltsplatzhalter
- Hinweistext
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie Text-, Bild-, Diagramm- und Inhaltsplatzhalter inspizieren und bearbeiten und die Platzhaltervererbung mit Aspose.Slides für PHP via Java verstehen."
---
## **Übersicht**

Ein Platzhalter ist eine Form, die eine Position für eine bestimmte Art von Inhalt in einer Präsentationsvorlage reserviert. Häufige Beispiele sind Titel‑, Text‑, Bild‑, Diagramm‑ und allgemeine Inhaltsplatzhalter. Im Gegensatz zu einer normalen Form kann ein Platzhalter seine Position, Größe, Formatierung und andere Einstellungen von einer Layout‑Folien‑ oder Master‑Folien‑Vorlage erben.

Aspose.Slides stellt Platzhalterinformationen über die [Shape::getPlaceholder](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/getplaceholder/)‑Methode bereit. Die Methode gibt ein [Placeholder](https://reference.aspose.com/slides/de/php-java/aspose.slides/placeholder/)‑Objekt zurück oder `null` für eine normale Form. Verwenden Sie [Placeholder::getType](https://reference.aspose.com/slides/de/php-java/aspose.slides/placeholder/gettype/), um zu bestimmen, welchen Inhalt der Platzhalter enthalten soll.

Die Formklasse bleibt nach Kenntnis des Platzhaltertyps wichtig:

- Ein leerer Text‑, Bild‑, Diagramm‑ oder Inhaltsplatzhalter wird üblicherweise durch ein [AutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/) dargestellt.
- Ein gefüllter Bildplatzhalter kann durch ein [PictureFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/pictureframe/) dargestellt werden.
- Ein gefüllter Diagrammplatzhalter kann durch ein [Chart](https://reference.aspose.com/slides/de/php-java/aspose.slides/chart/) dargestellt werden.
- Ein Inhaltsplatzhalter kann mehrere Arten von Inhalt enthalten. Prüfen Sie sowohl [Placeholder::getType](https://reference.aspose.com/slides/de/php-java/aspose.slides/placeholder/gettype/) als auch die Laufzeit‑Formklasse, anstatt anzunehmen, dass jeder Platzhalter ein [AutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/) ist.

{{% alert color="warning" title="Warning" %}}
[Placeholder::getType](https://reference.aspose.com/slides/de/php-java/aspose.slides/placeholder/gettype/) beschreibt die Rolle eines Platzhalters; sie garantiert nicht die Laufzeit‑Formklasse. Überprüfen Sie stets den Typ, bevor Sie auf text‑, bild‑, diagramm‑, tabellen‑ oder medienspezifische Mitglieder zugreifen.
{{% /alert %}}

## **Verstehen der Platzhaltervererbung**

Platzhalter bilden eine Hierarchie:

1. Eine Master‑Folien definiert wiederverwendbare Stile und in einigen Fällen Master‑Platzhalter.
2. Eine Layout‑Folien definiert das Layout, das von einer oder mehreren normalen Folien verwendet wird, und kann vom Master erben.
3. Eine normale Folie enthält die Platzhalter für diese Folie und kann vom zugehörigen Layout erben.

Rufen Sie [Shape::getBasePlaceholder](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/getbaseplaceholder/) auf, um eine Ebene in dieser Hierarchie nach oben zu gehen. Ein Folien‑Platzhalter liefert normalerweise seinen Layout‑Platzhalter; ein Layout‑Platzhalter kann seinen Master‑Platzhalter zurückgeben. Die Methode gibt `null` zurück, wenn die Form keinen Basis‑Platzhalter hat.

Das folgende Beispiel listet die Platzhalter der ersten Folie auf und gibt deren Basis‑Platzhalter aus:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        $shapeClass = $shape->getClass();
        $shapeClassNameValue = $shapeClass->getSimpleName();
        $shapeClassName = java_values($shapeClassNameValue);
        echo "Slide placeholder: " . $placeholderType . "; shape class: " . $shapeClassName . PHP_EOL;

        $layoutPlaceholder = $shape->getBasePlaceholder();
        if (!java_is_null($layoutPlaceholder)) {
            $layoutPlaceholderInfo = $layoutPlaceholder->getPlaceholder();
            if (!java_is_null($layoutPlaceholderInfo)) {
                $layoutPlaceholderTypeValue = $layoutPlaceholderInfo->getType();
                $layoutPlaceholderType = java_values($layoutPlaceholderTypeValue);
                echo "  Layout placeholder: " . $layoutPlaceholderType . PHP_EOL;
            }

            $masterPlaceholder = $layoutPlaceholder->getBasePlaceholder();
            if (!java_is_null($masterPlaceholder)) {
                $masterPlaceholderInfo = $masterPlaceholder->getPlaceholder();
                if (!java_is_null($masterPlaceholderInfo)) {
                    $masterPlaceholderTypeValue = $masterPlaceholderInfo->getType();
                    $masterPlaceholderType = java_values($masterPlaceholderTypeValue);
                    echo "  Master placeholder: " . $masterPlaceholderType . PHP_EOL;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Das Bearbeiten eines Platzhalters auf einer normalen Folie erstellt oder ändert eine lokale Überschreibung für diese Folie. Das Bearbeiten des zugehörigen Layouts oder Masters kann alle Folien beeinflussen, die diese Einstellung noch erben. Eine lokale gewöhnliche Form hat keinen Basis‑Platzhalter und beginnt nicht zu erben, nur weil sie dieselben Koordinaten belegt.

## **Text in einem Platzhalter ändern**

Titel‑, zentrierte Titel‑, Untertitel‑, Text‑ und Inhaltsplatzhalter unterstützen in der Regel Text. Prüfen Sie, ob es sich um ein [AutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/) handelt, bevor Sie dessen [getTextFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/gettextframe/)‑Methode verwenden.

Dieses Beispiel aktualisiert den ersten Titel‑Platzhalter auf der ersten Folie und speichert das Ergebnis:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $titleShape = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) {
            $titleShape = $shape;
            break;
        }
    }

    if ($titleShape === null) {
        throw new RuntimeException("The first slide does not contain a title placeholder.");
    }

    $titleShape->getTextFrame()->setText("Quarterly Business Review");
    $presentation->save("title-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Dieses Muster vermeidet die Behandlung von Bild‑, Diagramm‑, Tabellen‑ oder Medien‑Platzhaltern als [AutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/)-Objekte. Es identifiziert den Platzhalter außerdem nach Zweck, anstatt sich auf einen fragilen Form‑Index zu verlassen.

## **Hinweistext auf einem Layout festlegen**

Hinweistext ist die Entwurfs‑Anweisung, die in einem leeren Platzhalter angezeigt wird, z. B. *Klicken Sie, um Titel hinzuzufügen*. Legen Sie benutzerdefinierten Hinweistext im Layout‑Platzhalter fest, anstatt zu versuchen, ihn über die Formsammlung einer normalen Folie zu erreichen. Greifen Sie über [Slide::getLayoutSlide](https://reference.aspose.com/slides/de/php-java/aspose.slides/slide/#getLayoutSlide) auf das Layout zu und iterieren Sie über die Sammlung, die von [BaseSlide::getShapes](https://reference.aspose.com/slides/de/php-java/aspose.slides/baseslide/#getShapes) zurückgegeben wird.

Das folgende Beispiel ändert die Titel‑ und Untertitel‑Hinweise im Layout, das von der ersten Folie verwendet wird:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $slide->getLayoutSlide();
    $shapes = $layoutSlide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) {
            $shape->getTextFrame()->setText("Enter a concise slide title");
        } elseif ($placeholderType === PlaceholderType::Subtitle) {
            $shape->getTextFrame()->setText("Enter a subtitle or reporting period");
        }
    }

    $presentation->save("custom-placeholder-prompts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hinweistext ist kein normaler Folieninhalt. Er ist für leere Platzhalter in Bearbeitungsprogrammen wie PowerPoint gedacht. Sobald ein Benutzer oder ein Programm echten Inhalt bereitstellt, wird der Hinweis nicht mehr angezeigt. Das Ändern eines Hinweises ersetzt zudem nicht den bestehenden Text auf Folien, die das Layout verwenden.

## **Bildplatzhalter aktualisieren**

Es gibt zwei zu behandelnde Fälle:

- Wenn der Bildplatzhalter bereits gefüllt ist und durch ein [PictureFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/pictureframe/) dargestellt wird, ersetzen Sie das Bild über [PictureFillFormat::getPicture](https://reference.aspose.com/slides/de/php-java/aspose.slides/picturefillformat/getpicture/) und [SlidesPicture::setImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/slidespicture/setimage/).
- Wenn er noch ein leerer Platzhalter ist, fügen Sie mit [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/shapecollection/addpictureframe/) an den Koordinaten des Platzhalters einen Bildrahmen ein und entfernen Sie den leeren Platzhalter.

Das nächste Beispiel unterstützt beide Fälle und speichert die Präsentation:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("picture-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $pictureFrameClass = new JavaClass("com.aspose.slides.PictureFrame");
    $picturePlaceholder = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Picture) {
            $picturePlaceholder = $shape;
            break;
        }
    }

    if ($picturePlaceholder === null) {
        throw new RuntimeException("The first slide does not contain a picture placeholder.");
    }

    $imageData = file_get_contents("replacement.png");
    $image = $presentation->getImages()->addImage($imageData);

    if (java_instanceof($picturePlaceholder, $pictureFrameClass)) {
        $picture = $picturePlaceholder->getPictureFormat()->getPicture();
        $picture->setImage($image);
    } else {
        $x = $picturePlaceholder->getX();
        $y = $picturePlaceholder->getY();
        $width = $picturePlaceholder->getWidth();
        $height = $picturePlaceholder->getHeight();
        $shapes->addPictureFrame(ShapeType::Rectangle, $x, $y, $width, $height, $image);
        $shapes->remove($picturePlaceholder);
    }

    $presentation->save("picture-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Der für einen leeren Platzhalter erstellte Ersatz ist ein lokaler Bildrahmen, kein neuer Platzhalter, weil [Shape::getPlaceholder](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/getplaceholder/) keinen Setter bereitstellt. Er bewahrt die reservierte Position, erbt jedoch kein platzhalterspezifisches Verhalten mehr. Wenn das Beibehalten der Platzhalterbeziehung essenziell ist, bereiten Sie den Platzhalter zuerst in PowerPoint vor und füllen Sie ihn, dann aktualisieren Sie den resultierenden [PictureFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/pictureframe/) mit Aspose.Slides.

Für Bildtransparenz, Zuschneiden und andere bild‑spezifische Effekte siehe [Manage Picture Frames](/slides/de/php-java/picture-frame/). Diese Vorgänge betreffen den Bildrahmen bzw. den Bildfüllungs‑Effekt, nicht die Platzhalter‑Metadaten.

## **Arbeiten mit Diagramm‑ und Inhaltsplatzhaltern**

Ein gefüllter Diagramm‑Platzhalter kann durch ein [Chart](https://reference.aspose.com/slides/de/php-java/aspose.slides/chart/) dargestellt werden. Dieses Beispiel findet ein solches Diagramm sowohl anhand des Platzhaltertyps als auch der Laufzeit‑Klasse, ändert dessen Titel und speichert die Datei:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("chart-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $chartClass = new JavaClass("com.aspose.slides.Chart");
    $placeholderChart = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $chartClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Chart) {
            $placeholderChart = $shape;
            break;
        }
    }

    if ($placeholderChart === null) {
        throw new RuntimeException("The first slide does not contain a populated chart placeholder.");
    }

    $placeholderChart->setTitle(true);
    $placeholderChart->getChartTitle()->addTextFrameForOverriding("Quarterly Revenue");
    $presentation->save("chart-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ein allgemeiner Inhaltsplatzhalter hat üblicherweise [PlaceholderType::Object](https://reference.aspose.com/slides/de/php-java/aspose.slides/placeholdertype/). In PowerPoint fungiert er als Starter für mehrere Inhaltstypen, darunter Diagramme, Tabellen, Diagramme, Bilder und Medien. Nachdem er gefüllt wurde, prüfen Sie die tatsächliche Formklasse, um zu erfahren, was er enthält. Spezialisierte Layouts können außerdem [PlaceholderType::Chart](https://reference.aspose.com/slides/de/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/de/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/de/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/de/php-java/aspose.slides/placeholdertype/) oder [PlaceholderType::Diagram](https://reference.aspose.com/slides/de/php-java/aspose.slides/placeholdertype/) aufweisen.

Aspose.Slides wandelt einen leeren [AutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/)‑Platzhalter nicht allein durch Ändern von [Placeholder::getType](https://reference.aspose.com/slides/de/php-java/aspose.slides/placeholder/gettype/) in ein [Chart](https://reference.aspose.com/slides/de/php-java/aspose.slides/chart/) um; der Typ kann über die Klasse nicht geändert werden. Um ein leeres Diagramm‑ oder Inhaltsfeld programmgesteuert zu füllen, fügen Sie das erforderliche Objekt an den Koordinaten des Platzhalters ein und entfernen anschließend den leeren Platzhalter. Das folgende Beispiel demonstriert dies für ein Diagramm:

```php
use aspose\slides\ChartType;
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("content-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $targetPlaceholder = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Chart || $placeholderType === PlaceholderType::Object) {
            $targetPlaceholder = $shape;
            break;
        }
    }

    if ($targetPlaceholder === null) {
        throw new RuntimeException("The first slide does not contain a chart or content placeholder.");
    }

    $x = $targetPlaceholder->getX();
    $y = $targetPlaceholder->getY();
    $width = $targetPlaceholder->getWidth();
    $height = $targetPlaceholder->getHeight();
    $chart = $shapes->addChart(ChartType::ClusteredColumn, $x, $y, $width, $height);
    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Quarterly Revenue");
    $shapes->remove($targetPlaceholder);
    $presentation->save("content-placeholder-replaced-with-chart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das hinzugefügte Diagramm ist ein gewöhnliches lokales Diagramm. Es belegt den Bereich des Platzhalters, erbt jedoch nicht vom Layout‑Platzhalter. Verwenden Sie die dedizierten [chart management articles](/slides/de/php-java/powerpoint-charts/), wenn Sie Kategorien, Serien oder Arbeitsblattdaten austauschen müssen.

## **Vollständiges Beispiel: Text‑ oder Bildinhalt aktualisieren**

Das folgende End‑zu‑Ende‑Beispiel öffnet eine Vorlage, durchsucht die erste Folie nach einem Titel‑ oder Bild‑Platzhalter, prüft die Platzhalter‑ und Formtypen, aktualisiert den entsprechenden Inhalt und speichert das Ergebnis. Das Beispiel vermeidet bewusst Annahmen über einen Form‑Index und behandelt nicht jeden Platzhalter als dieselbe Klasse.

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $pictureFrameClass = new JavaClass("com.aspose.slides.PictureFrame");
    $updated = false;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);

        if (($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) && java_instanceof($shape, $autoShapeClass)) {
            $shape->getTextFrame()->setText("Quarterly Business Review");
            $updated = true;
            break;
        }

        if ($placeholderType === PlaceholderType::Picture) {
            $imageData = file_get_contents("replacement.png");
            $image = $presentation->getImages()->addImage($imageData);

            if (java_instanceof($shape, $pictureFrameClass)) {
                $picture = $shape->getPictureFormat()->getPicture();
                $picture->setImage($image);
            } else {
                $x = $shape->getX();
                $y = $shape->getY();
                $width = $shape->getWidth();
                $height = $shape->getHeight();
                $shapes->addPictureFrame(ShapeType::Rectangle, $x, $y, $width, $height, $image);
                $shapes->remove($shape);
            }

            $updated = true;
            break;
        }
    }

    if (!$updated) {
        throw new RuntimeException("No supported title or picture placeholder was found on the first slide.");
    }

    $presentation->save("placeholder-content-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Was ist ein Basis‑Platzhalter?**

Ein Basis‑Platzhalter ist die entsprechende Form auf dem Layout oder Master, von der ein anderer Platzhalter erbt. Verwenden Sie [Shape::getBasePlaceholder](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/getbaseplaceholder/), um ihn abzurufen. Eine gewöhnliche lokale Form gibt `null` zurück, weil sie nicht Teil der Platzhalter‑Hierarchie ist.

**Kann ich alle Folientitel ändern, indem ich einen Layout‑Platzhalter bearbeite?**

Sie können über ein Layout vererbte Formatierungen oder Hinweistexte ändern, aber vorhandene Titelinhalte sind auf den normalen Folien gespeichert. Um den eigentlichen Titeltext in einer gesamten Präsentation zu ersetzen, iterieren Sie über die Folien und aktualisieren Sie jeden Titel‑Platzhalter.

**Wie verwalte ich Datums‑, Folien‑Nummer‑, Kopf‑ und Fußzeilen‑Platzhalter?**

Verwenden Sie die Header‑ und Footer‑Manager im jeweiligen Folien‑, Layout‑, Master‑, Notiz‑ oder Handzettel‑Bereich. Siehe [Manage Presentation Header and Footer](/slides/de/php-java/presentation-header-and-footer/) für vollständige Beispiele.