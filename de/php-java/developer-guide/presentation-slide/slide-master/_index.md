---
title: Verwalten von Folienmastern in Präsentationen mit PHP
linktitle: Folienmaster
type: docs
weight: 70
url: /de/php-java/slide-master/
keywords:
- Folienmaster
- Masterfolie
- PPT-Masterfolie
- mehrere Masterfolien
- Masterfolien vergleichen
- Hintergrund
- Platzhalter
- Masterfolie klonen
- Masterfolie kopieren
- Masterfolie duplizieren
- unbenutzte Masterfolie
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Verwalten Sie Folienmaster in Aspose.Slides für PHP über Java: Zugriff, Bearbeitung, Klonen, Vergleich und Entfernen von Masterfolien in PowerPoint- und OpenDocument-Präsentationen."
---
## **Übersicht**

Ein **Folienmaster** definiert gemeinsam genutzte Designeinstellungen für eine Gruppe von Folien. Er kann gemeinsame Formen, Logos, Hintergründe, Textstile, Designthemen und Fußzeileneinstellungen enthalten. In PowerPoint ist das Bearbeiten eines Folienmasters der übliche Weg, um eine Präsentation konsistent zu halten, ohne dieselbe Formatierung auf jeder Folie zu wiederholen.

Aspose.Slides für PHP via Java unterstützt dasselbe Modell. Eine Präsentation kann einen oder mehrere Folienmaster enthalten, und jeder Folienmaster kann mehrere Layout‑Folien enthalten. Normale Folien verweisen normalerweise nicht direkt auf einen Folienmaster. Stattdessen verwendet eine normale Folie eine Layout‑Folie, und diese Layout‑Folie gehört zu einem Folienmaster.

Die Hierarchie lautet:

1. **Folienmaster** – definiert das gemeinsam genutzte Design und Thema.  
1. **Layout‑Folie** – definiert eine spezifische Anordnung von Platzhaltern und Layout‑Formatierungen.  
1. **Normale Folie** – enthält den eigentlichen Präsentationsinhalt und verwendet eine Layout‑Folie.

![Die Hierarchie von Folienmastern, Layout‑Folien und normalen Folien](slide-master_2.jpg)

In Aspose.Slides wird ein Folienmaster durch die Klasse [MasterSlide](https://reference.aspose.com/slides/de/php-java/aspose.slides/masterslide/) repräsentiert. Alle Folienmaster in einer Präsentation sind über die Methode [Presentation.getMasters](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#getMasters) verfügbar, die ein [MasterSlideCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/masterslidecollection/)‑Objekt zurückgibt.

{{% alert color="info" title="Inheritance" %}}
Wenn dieselbe Eigenschaft auf mehreren Ebenen definiert ist, gewinnt die spezifischere Ebene. Beispiel: Wenn ein Folienmaster und eine Layout‑Folie beide einen Hintergrund definieren, verwenden Folien, die auf diesem Layout basieren, den Layout‑Hintergrund. Weitere Informationen zu Layout‑Folien finden Sie unter [Apply or Change Slide Layouts](/slides/de/php-java/slide-layout/).
{{% /alert %}}

## **Zugriff auf Folienmaster**

In PowerPoint können Sie die Folienmaster‑Ansicht über **Ansicht** > **Folienmaster** öffnen.

![Der Befehl Folienmaster im PowerPoint‑Register „Ansicht“](slide-master_3.jpg)

In Aspose.Slides verwenden Sie die Methode `getMasters`, um Folienmaster zu erhalten:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $firstMasterSlide = $presentation->getMasters()->get_Item(0);
    $masterSlideCount = $presentation->getMasters()->size();
    $firstMasterLayoutSlideCount = $firstMasterSlide->getLayoutSlides()->size();

    echo "Master slides: " . $masterSlideCount . PHP_EOL;
    echo "Layouts in the first master: " . $firstMasterLayoutSlideCount . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Sie können den von einer normalen Folie genutzten Folienmaster auch über deren Layout erhalten:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $slide->getLayoutSlide();
    $masterSlide = $layoutSlide->getMasterSlide();
    $masterSlideName = $masterSlide->getName();

    echo $masterSlideName . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Inhalt eines Folienmasters**

Ein Folienmaster ist ein folienähnliches Objekt. Er erweitert [BaseSlide](https://reference.aspose.com/slides/de/php-java/aspose.slides/baseslide/), sodass er viele der gleichen Folieneigenschaften wie normale und Layout‑Folien bereitstellt. Folienmasterspezifische Mitglieder sind auf der API‑Seite [MasterSlide](https://reference.aspose.com/slides/de/php-java/aspose.slides/masterslide/) aufgeführt.

Häufig genutzte Folienmaster‑Mitglieder sind:

| Mitglied | Zweck |
| --- | --- |
| `getBackground` | Legt den Hintergrund auf Master‑Ebene fest. |
| `getShapes` | Enthält Formen, die auf dem Master platziert sind, z. B. Logos, Bildrahmen und gemeinsam genutzten Text. |
| `getLayoutSlides` | Enthält die Layout‑Folien, die zum Master gehören. |
| `getThemeManager` | Bietet Zugriff auf die Master‑Theme‑APIs. |
| `getHeaderFooterManager` | Steuert Kopf‑ und Fußzeilen, Datum und Foliennummern für den Master und seine untergeordneten Layouts. |
| `getDependingSlides` | Gibt normale Folien zurück, die über ihre Layouts vom Master abhängen. |

## **Ein Bild zu einem Folienmaster hinzufügen**

Wenn Sie ein Bild zu einem Folienmaster hinzufügen, erscheint es auf Folien, die Layouts dieses Masters verwenden. Das ist nützlich für Logos, Wasserzeichen, dekorative Bänder und andere wiederkehrende Bildelemente.

Das folgende Beispiel fügt dem ersten Folienmaster ein Logo hinzu:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $logoImage = Images::fromFile("logo.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($logoImage);
    } finally {
        $logoImage->dispose();
    }

    $masterSlide->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        80,
        80,
        $presentationImage
    );

    $presentation->save("presentation-with-logo.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Weitere Informationen zu Bildrahmen finden Sie unter [Picture Frame](/slides/de/php-java/picture-frame/).

## **Sichtbarkeit von Master‑Grafiken steuern**

Verwenden Sie [BaseSlide::setShowMasterShapes](https://reference.aspose.com/slides/de/php-java/aspose.slides/baseslide/#setShowMasterShapes), um geerbte Master‑Grafiken, wie Logos oder dekorative Formen, auszublenden, ohne sie vom Master zu löschen. Übergeben Sie `false` an [Slide::setShowMasterShapes](https://reference.aspose.com/slides/de/php-java/aspose.slides/slide/#setShowMasterShapes) auf der Folie, die diese Grafiken weglassen soll, und lassen Sie es auf Folien, die sie anzeigen sollen, auf `true` gesetzt.

Das folgende eigenständige Beispiel erstellt ein blaues dekoratives Band auf einem Master und zwei Folien, die dasselbe leere Layout verwenden. Das Band ist auf der ersten Folie sichtbar und auf der zweiten verborgen. Keine Eingabe‑Präsentation oder Bilddatei ist erforderlich.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $layoutSlide = $masterSlide->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $layoutSlide->setShowMasterShapes(true);

    $slideHeight = java_values($presentation->getSlideSize()->getSize()->getHeight());
    $band = $masterSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, 60, $slideHeight);
    $bandColor = new Java("java.awt.Color", 70, 130, 180);
    $band->getFillFormat()->setFillType(FillType::Solid);
    $band->getFillFormat()->getSolidFillColor()->setColor($bandColor);
    $band->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $visibleSlide = $presentation->getSlides()->get_Item(0);
    $visibleSlide->setLayoutSlide($layoutSlide);
    $visibleSlide->getShapes()->clear();

    $hiddenSlide = $presentation->getSlides()->addEmptySlide($layoutSlide);

    $visibleSlide->setShowMasterShapes(true);
    $hiddenSlide->setShowMasterShapes(false);

    $presentation->save("master-graphics.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Beispiel verwendet das Layout **Blank**, das mit einer neuen Präsentation geliefert wird, und entfernt die eigenen Platzhalter der Ausgangsfolie.

### **Geltungsbereich der Einstellung wählen**

Eine normale Folie greift über [Slide::getLayoutSlide](https://reference.aspose.com/slides/de/php-java/aspose.slides/slide/#getLayoutSlide) und [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/de/php-java/aspose.slides/layoutslide/#getMasterSlide) auf ihren Master zu. Das Setzen der Eigenschaft auf einer einzelnen Folie wirkt nur auf diese Folie. Das Übergeben von `false` an [LayoutSlide::setShowMasterShapes](https://reference.aspose.com/slides/de/php-java/aspose.slides/layoutslide/#setShowMasterShapes) blendet Master‑Grafiken für alle Folien aus, die dieses geteilte Layout verwenden, selbst wenn deren eigene Einstellung `true` ist. Um Grafiken nur auf einer Folie zu verbergen, ändern Sie die Folienspezifische Eigenschaft und lassen das geteilte Layout unverändert.

Die Einstellung wird nicht als Sichtbarkeitssteuerung auf dem Folienmaster selbst unterstützt. Auf einem Master gibt [getShowMasterShapes](https://reference.aspose.com/slides/de/php-java/aspose.slides/masterslide/#getShowMasterShapes) immer `false` zurück, und das Übergeben von `true` an [setShowMasterShapes](https://reference.aspose.com/slides/de/php-java/aspose.slides/masterslide/#setShowMasterShapes) löst eine Ausnahme aus. Wenden Sie sie stattdessen auf eine normale Folie oder ein Layout an.

### **Grafiken vom Hintergrund unterscheiden**

| Vorgang | Wirkung |
| --- | --- |
| Master‑Grafiken ausblenden | Steuert die Sichtbarkeit geerbter Master‑Formen, ohne sie zu löschen oder die eigenen Formen der Folie zu ändern. |
| Folienhintergrund füllen | Ändert die Hintergrundfarbe, den Farbverlauf oder das Bild. Master‑Grafiken sind separate Formen und können über diesem Hintergrund sichtbar bleiben. Siehe [Presentation Background](/slides/de/php-java/presentation-background/). |
| Form vom Master löschen | Entfernt die gemeinsam genutzte Quellform, sodass sie nicht mehr für irgendeine Folie, die diesen Master verwendet, verfügbar ist. |

## **Arbeiten mit Platzhaltern**

Platzhalter werden normalerweise auf Layout‑Folien definiert. Der Folienmaster stellt den gemeinsamen Stil und das Theme bereit, das diese Layouts erben, während jedes Layout entscheidet, welche Platzhalter verfügbar sind und wo sie platziert werden.

In PowerPoint sind Platzhalterbefehle in der Folienmaster‑Ansicht verfügbar.

![Der Befehl „Platzhalter einfügen“ in der PowerPoint‑Folienmaster‑Ansicht](slide-master_5.png)

Um neue Platzhalter mit Aspose.Slides hinzuzufügen, arbeiten Sie mit der Layout‑Folie, die zum Master gehört:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $blankLayoutSlideName = "Custom Blank";
    $blankLayoutSlide = $masterSlide->getLayoutSlides()->add(
        SlideLayoutType::Blank,
        $blankLayoutSlideName
    );

    $blankLayoutSlide->getPlaceholderManager()->addTextPlaceholder(
        60,
        120,
        600,
        80
    );

    $presentation->getSlides()->addEmptySlide($blankLayoutSlide);
    $presentation->save("presentation-with-placeholder.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sie können auch bereits vorhandene Platzhalterformen auf einem Folienmaster formatieren. Das folgende Beispiel findet den Titel‑Platzhalter und wendet eine lineare Farbverlauf‑Füllung an:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $titlePlaceholder = findPlaceholder($masterSlide, PlaceholderType::Title);

    if (!java_is_null($titlePlaceholder)) {
        $redGradientColor = java("java.awt.Color")->RED;
        $purpleGradientColor = new Java("java.awt.Color", 128, 0, 128);

        $fillFormat = $titlePlaceholder->getFillFormat();
        $fillFormat->setFillType(FillType::Gradient);
        $gradientFormat = $fillFormat->getGradientFormat();
        $gradientFormat->setGradientShape(GradientShape::Linear);
        $gradientStops = $gradientFormat->getGradientStops();
        $gradientStops->add(0, $redGradientColor);
        $gradientStops->add(255, $purpleGradientColor);
    }

    $presentation->save("presentation-title-style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

function findPlaceholder($masterSlide, $placeholderType)
{
    $shapesCount = java_values($masterSlide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapesCount; $shapeIndex++) {
        $shape = $masterSlide->getShapes()->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();

        if (!java_is_null($placeholder) && java_values($placeholder->getType()) == $placeholderType) {
            return $shape;
        }
    }

    return null;
}
```

![Formatierter Titel‑Platzhalter, geerbt von normalen Folien](slide-master_8.png)

Weitere Optionen zur Platzhalter‑ und Textformatierung finden Sie unter [Set Prompt Text in Placeholder](/slides/de/php-java/manage-placeholder/) und [Text Formatting](/slides/de/php-java/text-formatting/).

## **Hintergrund eines Folienmasters ändern**

Ein Master‑Hintergrund wird von Layouts und Folien geerbt, die ihn nicht überschreiben. Das folgende Beispiel setzt eine einfarbige Hintergrundfarbe für den ersten Folienmaster:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $forestGreenColor = new Java("java.awt.Color", 34, 139, 34);

    $background = $masterSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $fillFormat = $background->getFillFormat();
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor($forestGreenColor);

    $presentation->save("presentation-master-background.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Verwandte Themen finden Sie unter [Presentation Background](/slides/de/php-java/presentation-background/) und [Presentation Theme](/slides/de/php-java/presentation-theme/).

## **Einen Folienmaster in eine andere Präsentation klonen**

Verwenden Sie `addClone` aus der [MasterSlideCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/masterslidecollection/), um einen Folienmaster in eine andere Präsentation zu kopieren. Der kopierte Master kann dann von Layouts und Folien in der Zielpräsentation verwendet werden.

```php
$sourcePresentation = new Presentation("source.pptx");
$destinationPresentation = new Presentation("destination.pptx");
try {
    $sourceMasterSlide = $sourcePresentation->getMasters()->get_Item(0);
    $clonedMasterSlide = $destinationPresentation->getMasters()->addClone($sourceMasterSlide);

    $destinationPresentation->save("destination-with-master.pptx", SaveFormat::Pptx);
} finally {
    $destinationPresentation->dispose();
    $sourcePresentation->dispose();
}
```

Wenn Sie normale Folien zusammen mit ihrem Master klonen müssen, siehe [Clone Slides](/slides/de/php-java/clone-slides/).

## **Mehrere Folienmaster hinzufügen**

Eine Präsentation kann mehrere Folienmaster enthalten. Das ist nützlich, wenn verschiedene Abschnitte unterschiedliche Markenauftritte, Seitenstrukturen oder Theme‑Einstellungen benötigen.

![PowerPoint‑Befehle zum Einfügen und Verwalten von Folienmastern](slide-master_9.jpg)

Das folgende Beispiel klont den Standard‑Master, verleiht dem Klon einen anderen Hintergrund, erstellt ein Layout unter diesem geklonten Master und fügt eine neue Folie basierend auf diesem Layout hinzu:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $defaultMasterSlide = $presentation->getMasters()->get_Item(0);
    $sectionMasterSlide = $presentation->getMasters()->addClone($defaultMasterSlide);
    $lightSteelBlueColor = new Java("java.awt.Color", 176, 196, 222);

    $background = $sectionMasterSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $fillFormat = $background->getFillFormat();
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor($lightSteelBlueColor);

    $sourceBlankLayout = $defaultMasterSlide->getLayoutSlides()->get_Item(0);
    $sectionBlankLayout = $sectionMasterSlide->getLayoutSlides()->addClone($sourceBlankLayout);

    $presentation->getSlides()->addEmptySlide($sectionBlankLayout);
    $presentation->save("presentation-with-multiple-masters.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Folienmaster vergleichen**

Folienmaster können mit der von [BaseSlide](https://reference.aspose.com/slides/de/php-java/aspose.slides/baseslide/) geerbten Methode `equals` verglichen werden. Der Vergleich prüft Struktur und statischen Inhalt wie Formen, Text, Formatierung, Animationen und andere Folieneinstellungen. Er vergleicht nicht eindeutige Bezeichner wie Folien‑IDs oder dynamische Platzhalterwerte wie das aktuelle Datum.

```php
$firstPresentation = new Presentation("first.pptx");
$secondPresentation = new Presentation("second.pptx");
try {
    $firstPresentationMasterCount = java_values($firstPresentation->getMasters()->size());
    $secondPresentationMasterCount = java_values($secondPresentation->getMasters()->size());

    for ($firstMasterIndex = 0; $firstMasterIndex < $firstPresentationMasterCount; $firstMasterIndex++) {
        for ($secondMasterIndex = 0; $secondMasterIndex < $secondPresentationMasterCount; $secondMasterIndex++) {
            $firstMasterSlide = $firstPresentation->getMasters()->get_Item($firstMasterIndex);
            $secondMasterSlide = $secondPresentation->getMasters()->get_Item($secondMasterIndex);
            $areMasterSlidesEqual = $firstMasterSlide->equals($secondMasterSlide);

            if ($areMasterSlidesEqual) {
                echo "first.pptx master #" . $firstMasterIndex .
                    " equals second.pptx master #" . $secondMasterIndex . PHP_EOL;
            }
        }
    }
} finally {
    $secondPresentation->dispose();
    $firstPresentation->dispose();
}
```

Weitere Informationen finden Sie unter [Compare Presentation Slides](/slides/de/php-java/compare-slides/).

## **Folienmaster‑Ansicht als Standardansicht festlegen**

Verwenden Sie die Methode `setLastView` auf [ViewProperties](https://reference.aspose.com/slides/de/php-java/aspose.slides/viewproperties/), um die Ansicht zu steuern, die PowerPoint zuerst öffnet. Das folgende Beispiel öffnet die Präsentation in der Folienmaster‑Ansicht:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("presentation-master-view.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Weitere Ansichtseinstellungen finden Sie unter [Save Presentation](/slides/de/php-java/save-presentation/).

## **Unbenutzte Folienmaster entfernen**

Präsentationen enthalten manchmal Folienmaster, die von keiner normalen Folie mehr verwendet werden. Das Entfernen unbenutzter Master kann die Dateigröße reduzieren und die Vorlagenwartung vereinfachen.

Verwenden Sie `removeUnused` aus der [MasterSlideCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/masterslidecollection/), um unbenutzte Master aus der `getMasters`‑Sammlung zu entfernen:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getMasters()->removeUnused(true);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sie können auch die Low‑Code‑Methode `removeUnusedMasterSlides` aus der Klasse [Compress](https://reference.aspose.com/slides/de/php-java/aspose.slides/compress/) verwenden:

```php
$presentation = new Presentation("presentation.pptx");
try {
    Compress::removeUnusedMasterSlides($presentation);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Was ist der Unterschied zwischen einem Folienmaster und einer Layout‑Folie?**

Ein Folienmaster definiert gemeinsame Designeinstellungen wie Theme, Hintergrund, gemeinsame Formen und Textstile. Eine Layout‑Folie gehört zu einem Folienmaster und definiert eine spezifische Anordnung von Platzhaltern. Eine normale Folie verwendet eine Layout‑Folie und erbt somit sowohl vom Layout als auch vom Master.

**Kann eine Präsentation mehrere Folienmaster enthalten?**

Ja. Eine Präsentation kann mehrere Folienmaster enthalten. Verwenden Sie mehrere Master, wenn unterschiedliche Abschnitte verschiedene visuelle Systeme oder Markenauftritte benötigen.

**Soll ich Platzhalter zu einem Folienmaster oder zu einer Layout‑Folie hinzufügen?**

In den meisten Fällen platzieren Sie Platzhalter auf Layout‑Folien. Gemeinsame Bildelemente und Formatierungen kommen auf den Folienmaster, während Inhaltsplatzhalter auf den Layout‑Folien liegen, die von normalen Folien verwendet werden.

**Kann ich einen Folienmaster löschen, der noch verwendet wird?**

Nein. Ein Folienmaster, der abhängige Folien hat, kann nicht sicher direkt entfernt werden. Verschieben Sie zuerst diese Folien zu Layouts unter einem anderen Master oder verwenden Sie eine Bereinigungs‑Methode, die nur unbenutzte Master entfernt.