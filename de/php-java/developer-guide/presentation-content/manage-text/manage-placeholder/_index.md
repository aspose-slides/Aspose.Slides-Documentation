---
title: Verwalten von Präsentationsplatzhaltern in PHP
linktitle: Platzhalter verwalten
type: docs
weight: 10
url: /de/php-java/manage-placeholder/
keywords:
- Platzhalter
- Text‑Platzhalter
- Bild‑Platzhalter
- Diagramm‑Platzhalter
- Inhalts‑Platzhalter
- Aufforderungstext
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie Text‑, Bild‑, Diagramm‑ und Inhalts‑Platzhalter prüfen und bearbeiten und die Platzhalter‑Vererbung mit Aspose.Slides für PHP via Java verstehen."
---
## **Übersicht**

Ein Platzhalter ist eine Form, die eine Position für eine bestimmte Art von Inhalt in einer Präsentationsvorlage reserviert. Häufige Beispiele sind Titel‑, Text‑, Bild‑, Diagramm‑ und allgemeine Inhaltsplatzhalter. Im Gegensatz zu einer normalen Form kann ein Platzhalter seine Position, Größe, Formatierung und andere Einstellungen von einer Layout‑Folien‑ oder Master‑Folien‑Vorlage erben.

Aspose.Slides stellt Platzhalterinformationen über die [Shape::getPlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getplaceholder/)‑Methode bereit. Die Methode gibt ein [Placeholder](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/)‑Objekt oder `null` für eine normale Form zurück. Verwenden Sie [Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/), um zu bestimmen, welchen Inhalt der Platzhalter enthalten soll.

Die Formklasse ist nach dem Erkennen des Platzhaltertyps weiterhin relevant:

- Ein leerer Text‑, Bild‑, Diagramm‑ oder Inhaltsplatzhalter wird üblicherweise durch ein [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) dargestellt.
- Ein ausgefüllter Bildplatzhalter kann durch ein [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) dargestellt werden.
- Ein ausgefüllter Diagramm‑Platzhalter kann durch ein [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/) dargestellt werden.
- Ein Inhaltsplatzhalter kann verschiedene Arten von Inhalt enthalten. Prüfen Sie sowohl [Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) als auch die Laufzeit‑Formklasse, anstatt anzunehmen, dass jeder Platzhalter ein [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) ist.

{{% alert color="warning" title="Warning" %}}
[Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) beschreibt die Rolle eines Platzhalters; sie garantiert nicht die Laufzeit‑Klasse der Form. Verwenden Sie stets eine Typprüfung, bevor Sie auf text‑, bild‑, diagramm‑, tabellen‑ oder medienspezifische Member zugreifen.
{{% /alert %}}

## **Verstehen der Platzhalter‑Vererbung**

Platzhalter bilden eine Hierarchie:

1. Eine Master‑Folien‑Vorlage definiert wiederverwendbare Stile und in manchen Fällen Master‑Platzhalter.
2. Eine Layout‑Folien‑Vorlage definiert die Anordnung, die von einer oder mehreren normalen Folien verwendet wird, und kann vom Master erben.
3. Eine normale Folie enthält die Platzhalter für diese Folie und kann von ihrem Layout erben.

Rufen Sie [Shape::getBasePlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getbaseplaceholder/) auf, um eine Ebene die Hierarchie hinaufzusteigen. Ein Folien‑Platzhalter gibt normalerweise seinen Layout‑Platzhalter zurück; ein Layout‑Platzhalter kann seinen Master‑Platzhalter zurückgeben. Die Methode gibt `null` zurück, wenn die Form keinen Basis‑Platzhalter hat.

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

## **Entfernen des Platzhalter‑Status**

Beim Anpassen einer Vorlage verwenden Sie [Shape::removePlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/removeplaceholder/), um ein vorhandenes Objekt als gewöhnliche Form zu erhalten. Seine [getPlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getplaceholder/)‑Methode gibt `null` zurück, aber die Form bleibt in der Folien‑Sammlung. Im Gegensatz dazu löscht [ShapeCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/remove/) die Form aus dieser Sammlung.

Das folgende Beispiel erfordert `template.pptx` mit mindestens einer Folie und einem nicht leeren Text‑Platzhalter auf der ersten Folie. Verwenden Sie einen Platzhalter mit vom Layout oder Master geerbter Formatierung, um die Wirkung des Entfernens dieser Beziehung zu sehen. Das Beispiel prüft, dass dieselbe Form erhalten bleibt, ruft die Methode erneut auf der nun gewöhnlichen Form auf und speichert das Ergebnis.

{{% alert color="warning" title="Warning" %}}
Das Entfernen des Platzhalter‑Status bewahrt nicht automatisch vererbte Anzeigeeinstellungen. Das untenstehende Beispiel lässt diese Einstellungen bewusst unverändert, sodass die Ausgabe anders aussehen kann. Eine Form, deren Position und Größe vollständig geerbt wurden, kann nach dem Aufruf Null‑Koordinaten und -Abmessungen besitzen und unsichtbar werden, obwohl sie in der Sammlung verbleibt.
{{% /alert %}}

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $found = false;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        $textFrame = $shape->getTextFrame();
        if (java_is_null($placeholder) || java_is_null($textFrame)) {
            continue;
        }

        $textValue = $textFrame->getText();
        if (java_is_null($textValue)) {
            continue;
        }
        $text = java_values($textValue);
        if ($text === "") {
            continue;
        }

        $shape->removePlaceholder();

        $placeholder = $shape->getPlaceholder();
        $retainedShape = $slide->getShapes()->get_Item($shapeIndex);
        $sameShapeValue = $shape->equals($retainedShape);
        $sameShape = java_values($sameShapeValue);
        $remainingCountValue = $slide->getShapes()->size();
        $remainingCount = java_values($remainingCountValue);
        echo "Placeholder removed: " . (java_is_null($placeholder) ? "true" : "false") . PHP_EOL;
        echo "Same shape retained: " . ($sameShape ? "true" : "false") . PHP_EOL;
        echo "Shape count unchanged: " . ($remainingCount === $shapeCount ? "true" : "false") . PHP_EOL;

        // Aufruf der Methode auf einer gewöhnlichen Form hat keine Wirkung.
        $shape->removePlaceholder();
        $found = true;
        break;
    }

    if ($found) {
        $presentation->save("placeholder-status-removed.pptx", SaveFormat::Pptx);
    } else {
        echo "No nonempty text placeholder was found on the first slide." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Für einen passenden Platzhalter geben alle drei Prüfungen `true` zurück. Der Text bleibt erhalten, aber vererbte Position, Größe, Drehung, Schriftart, Absatz‑Ausrichtung, Text‑Frame‑Ränder, vertikale Verankerung, Füll‑ und Linien‑Einstellungen können sich ändern, wenn die Platzhalter‑Beziehung entfernt wird. Beispielsweise kann die vererbte Titelformatierung auf die reguläre Textformatierung zurückfallen. Siehe [Slide Layout](/slides/de/php-java/slide-layout/) für weitere Informationen zu Layouts.

Um das beabsichtigte Aussehen zu bewahren, erfassen Sie die aufgelöste Position, Größe und Drehung vor dem Aufruf und kopieren Sie die erforderlichen effektiven Formatierungswerte in separate Variablen. Rufen Sie diese Werte über [PortionFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/geteffective/), [ParagraphFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/geteffective/), [TextFrameFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/geteffective/), [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/geteffective/) und [LineFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/geteffective/) ab. Verlassen Sie sich nicht nur auf die effektiven Format‑Objekte, da deren Text‑Formatierungswerte nach dem Entfernen der Beziehung geändert werden können. Wenden Sie die erfassten Werte anschließend explizit auf die gewöhnliche Form an, einschließlich Schriftfamilie, Größe, Stil, Farbe, Absatz‑Einstellungen, Text‑Frame‑Einstellungen, Füll‑ und Linien‑Eigenschaften Ihrer Vorlage.

Vererbte Formgeometrie muss möglicherweise ebenfalls explizit über [GeometryShape::setShapeType](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setShapeType) zugewiesen werden. Für einen rechteckigen Text‑Platzhalter bedeutet dies, [ShapeType::Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/shapetype/) zuzuweisen; das Wiederherstellen nur von Füll‑ und Linien‑Eigenschaften stellt das sichtbare Rechteck nicht wieder her. Vorlagen mit zusätzlichen Effekten oder komplexeren Formatierungen erfordern ebenfalls die Behandlung dieser Einstellungen.

## **Text in einem Platzhalter ändern**

Titel‑, zentrierte‑Titel‑, Untertitel‑, Text‑ und Text‑Platzhalter unterstützen normalerweise Text. Prüfen Sie auf ein [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/), bevor Sie dessen [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/gettextframe/)‑Methode verwenden.

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

Dieses Muster vermeidet das Behandeln von Bild‑, Diagramm‑, Tabellen‑ oder Medien‑Platzhaltern als [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)-Objekte. Es identifiziert den Platzhalter zudem nach Zweck statt nach einem fragilen Form‑Index.

## **Aufforderungstext auf einem Layout festlegen**

Aufforderungstext ist die Design‑Zeit‑Anweisung, die in einem leeren Platzhalter angezeigt wird, z. B. *Klicken, um Titel hinzuzufügen*. Legen Sie benutzerdefinierten Aufforderungstext am Layout‑Platzhalter fest, anstatt zu versuchen, ihn über die Form‑Sammlung einer normalen Folie zu erreichen. Greifen Sie über [Slide::getLayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getLayoutSlide) auf das Layout zu und iterieren Sie über die Sammlung, die [BaseSlide::getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes) zurückgibt.

Das folgende Beispiel ändert die Titel‑ und Untertitel‑Aufforderungen im Layout, das von der ersten Folie verwendet wird:

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

Aufforderungstext ist kein normaler Folien‑Inhalt. Er ist für leere Platzhalter in Bearbeitungs‑Anwendungen wie PowerPoint gedacht. Sobald ein Benutzer oder ein Programm echten Inhalt liefert, wird die Aufforderung nicht mehr angezeigt. Das Ändern einer Aufforderung ersetzt zudem keinen bestehenden Text auf Folien, die das Layout verwenden.

## **Ein Bild‑Platzhalter aktualisieren**

Es gibt zwei zu behandelnde Fälle:

- Wenn der Bild‑Platzhalter bereits gefüllt ist und durch ein [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) dargestellt wird, ersetzen Sie das Bild über [PictureFillFormat::getPicture](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/getpicture/) und [Picture::setImage](https://reference.aspose.com/slides/php-java/aspose.slides/picture/#setImage).
- Ist er noch ein leerer Platzhalter, fügen Sie an den Koordinaten des Platzhalters einen Bildrahmen mit [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addpictureframe/) hinzu und entfernen Sie den leeren Platzhalter.

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

Der Ersatz, der für einen leeren Platzhalter erstellt wird, ist ein lokaler Bildrahmen, kein neuer Platzhalter, weil [Shape::getPlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getplaceholder/) keinen Setter bietet. Er behält die reservierte Position bei, erbt jedoch nicht länger das platzhalterspezifische Verhalten. Wenn das Beibehalten der Platzhalter‑Beziehung wichtig ist, bereiten Sie den Platzhalter zunächst in PowerPoint vor und aktualisieren dann den resultierenden [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) mit Aspose.Slides.

Für Bild‑Transparenz, Zuschneiden und andere bild‑spezifische Effekte siehe [Manage Picture Frames](/slides/de/php-java/picture-frame/). Diese Vorgänge betreffen den Bildrahmen oder die Bild‑Füllung, nicht die Platzhalter‑Metadaten.

## **Arbeiten mit Diagramm‑ und Inhalts‑Platzhaltern**

Ein gefüllter Diagramm‑Platzhalter kann durch ein [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/) dargestellt werden. Dieses Beispiel findet ein solches Diagramm sowohl nach Platzhaltertyp als auch nach Laufzeit‑Klasse, ändert dessen Titel und speichert die Datei:

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

Ein allgemeiner Inhalts‑Platzhalter hat normalerweise [PlaceholderType::Object](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/). In PowerPoint dient er als Starter für mehrere Inhaltsarten, darunter Diagramme, Tabellen, Diagramme, Bilder und Medien. Nachdem er gefüllt wurde, prüfen Sie die tatsächliche Formklasse, um zu erfahren, was er enthält. Spezialisierte Layouts können zudem [PlaceholderType::Chart](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/) oder [PlaceholderType::Diagram](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/) aussetzen.

Aspose.Slides konvertiert einen leeren [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)‑Platzhalter nicht in ein [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/) allein durch Ändern von [Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/); der Typ kann über die Klasse nicht geändert werden. Um programmgesteuert ein leeres Diagramm‑ oder Inhalts‑Feld zu füllen, fügen Sie das erforderliche Objekt an den Koordinaten des Platzhalters ein und entfernen anschließend den leeren Platzhalter. Das folgende Beispiel macht dies für ein Diagramm:

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

Das hinzugefügte Diagramm ist ein gewöhnliches lokales Diagramm. Es belegt den Bereich des Platzhalters, erbt jedoch nicht vom Layout‑Platzhalter. Verwenden Sie die speziellen [chart management articles](/slides/de/php-java/powerpoint-charts/), wenn Sie Kategorien, Serien oder Arbeitsmappendaten ersetzen müssen.

## **Komplettes Beispiel: Text‑ oder Bild‑Inhalt aktualisieren**

Das folgende End‑zu‑Ende‑Beispiel öffnet eine Vorlage, durchsucht die erste Folie nach einem Titel‑ oder Bild‑Platzhalter, prüft die Platzhalter‑ und Formtypen, aktualisiert den entsprechenden Inhalt und speichert das Ergebnis. Das Beispiel vermeidet bewusst Annahmen über einen Form‑Index oder die Behandlung jedes Platzhalters als gleiche Klasse.

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

Ein Basis‑Platzhalter ist die entsprechende Form im Layout oder Master, von der ein anderer Platzhalter erbt. Verwenden Sie [Shape::getBasePlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getbaseplaceholder/), um ihn abzurufen. Eine gewöhnliche lokale Form gibt `null` zurück, weil sie nicht Teil der Platzhalter‑Hierarchie ist.

**Kann ich alle Folientitel ändern, indem ich einen Layout‑Platzhalter bearbeite?**

Sie können über ein Layout geerbte Formatierung oder den Aufforderungstext ändern, aber vorhandene Titel‑Inhalte werden auf den normalen Folien gespeichert. Um den tatsächlichen Titel‑Text einer gesamten Präsentation zu ersetzen, iterieren Sie über die Folien und aktualisieren jeden Titel‑Platzhalter.

**Wie verwalte ich Datums‑, Folien‑Nummer‑, Kopf‑ und Fuß‑Platzhalter?**

Verwenden Sie die Kopf‑ und Fuß‑Manager im jeweiligen Folien‑, Layout‑, Master‑, Notiz‑ oder Handout‑Umfang. Siehe [Manage Presentation Header and Footer](/slides/de/php-java/presentation-header-and-footer/) für umfassende Beispiele.