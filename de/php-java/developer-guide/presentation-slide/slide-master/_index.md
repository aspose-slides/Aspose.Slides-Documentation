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
description: "Verwalten von Folienmastern in Aspose.Slides für PHP über Java: Zugriff, Bearbeitung, Klonen, Vergleich und Entfernen von Masterfolien in PowerPoint- und OpenDocument‑Präsentationen."
---
## **Übersicht**

Ein **Folienmaster** definiert gemeinsam genutzte Designeinstellungen für eine Gruppe von Folien. Er kann gemeinsame Formen, Logos, Hintergründe, Textstile, Designthemen und Fußzeileneinstellungen enthalten. In PowerPoint ist das Bearbeiten eines Folienmasters die übliche Methode, um eine Präsentation konsistent zu halten, ohne dieselbe Formatierung auf jeder Folie zu wiederholen.

Aspose.Slides für PHP via Java unterstützt dasselbe Modell. Eine Präsentation kann einen oder mehrere Masterfolien enthalten, und jede Masterfolie kann mehrere Layoutfolien enthalten. Normale Folien verweisen normalerweise nicht direkt auf eine Masterfolie. Stattdessen verwendet eine normale Folie eine Layoutfolie, und diese Layoutfolie gehört zu einer Masterfolie.

Die Hierarchie lautet:

1. **Folienmaster** – definiert das gemeinsame Design und Thema.  
1. **Layoutfolie** – definiert eine spezifische Anordnung von Platzhaltern und Layout‑Formatierungen.  
1. **Normale Folie** – enthält den eigentlichen Präsentationsinhalt und verwendet eine Layoutfolie.

![Die Hierarchie von Masterfolien, Layoutfolien und normalen Folien](slide-master_2.jpg)

In Aspose.Slides wird ein Folienmaster durch die [MasterSlide](https://reference.aspose.com/slides/de/php-java/aspose.slides/masterslide/)‑Klasse repräsentiert. Alle Masterfolien einer Präsentation sind über die Methode [Presentation.getMasters](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#getMasters) verfügbar, die ein [MasterSlideCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/masterslidecollection/)‑Objekt zurückgibt.

{{% alert color="info" title="Vererbung" %}}

Wenn dieselbe Eigenschaft auf mehr als einer Ebene definiert ist, gewinnt die spezifischere Ebene. Beispiel: Wenn sowohl eine Masterfolie als auch eine Layoutfolie einen Hintergrund definieren, verwenden Folien, die auf diesem Layout basieren, den Hintergrund des Layouts. Weitere Informationen zu Layoutfolien finden Sie unter [Folienlayout anwenden oder ändern](/slides/de/php-java/slide-layout/).

{{% /alert %}}

## **Zugriff auf Folienmaster**

In PowerPoint können Sie die Folienmaster‑Ansicht über **Ansicht** > **Folienmaster** öffnen.

![Der Befehl Folienmaster auf der Registerkarte Ansicht in PowerPoint](slide-master_3.jpg)

In Aspose.Slides verwenden Sie die Methode `getMasters`, um auf Masterfolien zuzugreifen:

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

Sie können die Masterfolie, die von einer normalen Folie verwendet wird, über deren Layout erhalten:

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

## **Inhalt einer Folienmaster‑Folie**

Eine Masterfolie ist ein folienähnliches Objekt. Sie erweitert [BaseSlide](https://reference.aspose.com/slides/de/php-java/aspose.slides/baseslide/) und stellt somit viele der gleichen Folien‑Eigenschaften bereit, die auch von normalen und Layoutfolien verwendet werden. Master‑spezifische Mitglieder sind auf der API‑Seite [MasterSlide](https://reference.aspose.com/slides/de/php-java/aspose.slides/masterslide/) aufgelistet.

Häufig verwendete Member der Masterfolie sind:

| Member | Zweck |
| --- | --- |
| `getBackground` | Setzt den master‑level Folienhintergrund. |
| `getShapes` | Enthält Formen, die auf dem Master platziert sind, z. B. Logos, Bildrahmen und gemeinsam genutzten Text. |
| `getLayoutSlides` | Enthält die Layoutfolien, die zum Master gehören. |
| `getThemeManager` | Bietet Zugriff auf die Master‑Theme‑APIs. |
| `getHeaderFooterManager` | Steuert Kopf‑, Fußzeilen, Datumsangaben und Folienzahlen für den Master und seine untergeordneten Layouts. |
| `getDependingSlides` | Gibt normale Folien zurück, die über ihre Layouts vom Master abhängen. |

## **Ein Bild zur Folienmaster‑Folien hinzufügen**

Wenn Sie ein Bild zu einer Masterfolie hinzufügen, erscheint es auf Folien, die Layouts dieses Masters verwenden. Das ist nützlich für Logos, Wasserzeichen, dekorative Bänder und andere wiederkehrende Bildelemente.

Das folgende Beispiel fügt dem ersten Masterbild ein Logo hinzu:

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

## **Mit Platzhaltern arbeiten**

Platzhalter werden normalerweise auf Layoutfolien definiert. Der Folienmaster liefert den gemeinsamen Stil und das Thema, das diese Layouts erben, während jedes Layout entscheidet, welche Platzhalter verfügbar sind und wo sie platziert werden.

In PowerPoint sind Platzhalter‑Befehle in der Folienmaster‑Ansicht verfügbar.

![Der Befehl Platzhalter einfügen in der Folienmaster‑Ansicht von PowerPoint](slide-master_5.png)

Um mit Aspose.Slides neue Platzhalter hinzuzufügen, arbeiten Sie mit der Layoutfolie, die zum Master gehört:

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

Sie können auch Platzhalterformen formatieren, die bereits auf einer Masterfolie existieren. Das folgende Beispiel findet den Titel‑Platzhalter und wendet einen linearen Farbverlauf an:

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

![Formatierter Titel‑Platzhalter, der von normalen Folien geerbt wird](slide-master_8.png)

Weitere Optionen für Platzhalter‑ und Textformatierung finden Sie unter [Prompt‑Text im Platzhalter festlegen](/slides/de/php-java/manage-placeholder/) und [Textformatierung](/slides/de/php-java/text-formatting/).

## **Hintergrund einer Folienmaster‑Folien ändern**

Ein Master‑Hintergrund wird von Layouts und Folien übernommen, die ihn nicht überschreiben. Das folgende Beispiel setzt eine einfarbige Hintergrundfarbe für die erste Masterfolie:

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

Weitere verwandte Themen finden Sie unter [Präsentationshintergrund](/slides/de/php-java/presentation-background/) und [Präsentationsthema](/slides/de/php-java/presentation-theme/).

## **Eine Folienmaster‑Folien in eine andere Präsentation klonen**

Verwenden Sie `addClone` aus [MasterSlideCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/masterslidecollection/), um eine Masterfolie in eine andere Präsentation zu kopieren. Der kopierte Master kann dann von Layouts und Folien in der Zielpräsentation verwendet werden.

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

Wenn Sie normale Folien gemeinsam mit ihrem Master klonen müssen, siehe [Folien klonen](/slides/de/php-java/clone-slides/).

## **Mehrere Folienmaster‑Folien hinzufügen**

Eine Präsentation kann mehrere Masterfolien enthalten. Das ist nützlich, wenn verschiedene Abschnitte unterschiedliche Markenkennzeichnungen, Seitenstrukturen oder Theme‑Einstellungen benötigen.

![PowerPoint‑Befehle zum Einfügen und Verwalten von Masterfolien](slide-master_9.jpg)

Das folgende Beispiel klont den Standard‑Master, gibt dem Klon einen anderen Hintergrund, erstellt ein Layout unter diesem geklonten Master und fügt eine neue Folie basierend auf diesem Layout hinzu:

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

## **Folienmaster‑Folien vergleichen**

Masterfolien können mit der von [BaseSlide](https://reference.aspose.com/slides/de/php-java/aspose.slides/baseslide/) geerbten `equals`‑Methode verglichen werden. Der Vergleich prüft Struktur und statischen Inhalt, wie Formen, Text, Formatierung, Animationen und andere Folieneinstellungen. Er vergleicht nicht eindeutige Kennungen wie Folien‑IDs oder dynamische Platzhalterwerte wie das aktuelle Datum.

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

Weitere Informationen finden Sie unter [Präsentationsfolien vergleichen](/slides/de/php-java/compare-slides/).

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

Weitere Ansicht‑Einstellungen finden Sie unter [Präsentation speichern](/slides/de/php-java/save-presentation/).

## **Unbenutzte Masterfolien entfernen**

Präsentationen enthalten manchmal Masterfolien, die von keiner normalen Folie mehr verwendet werden. Das Entfernen unbenutzter Master kann die Dateigröße verringern und die Wartung von Vorlagen vereinfachen.

Verwenden Sie `removeUnused` aus [MasterSlideCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/masterslidecollection/), um unbenutzte Master aus der `getMasters`‑Sammlung zu entfernen:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getMasters()->removeUnused(true);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sie können auch die Low‑Code‑Methode `removeUnusedMasterSlides` aus der Klasse [Compress](https://reference.aspose.com/slides/de/php-java/aspose.slides/compress/) nutzen:

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

**Was ist der Unterschied zwischen einer Folienmaster‑Folien und einer Layoutfolie?**

Eine Folienmaster‑Folien definiert gemeinsam genutzte Designeinstellungen wie Thema, Hintergrund, gemeinsame Formen und Textstile. Eine Layoutfolie gehört zu einer Masterfolie und definiert eine spezifische Anordnung von Platzhaltern. Eine normale Folie verwendet eine Layoutfolie und erbt somit sowohl vom Layout als auch vom Master.

**Kann eine Präsentation mehrere Folienmaster‑Folien enthalten?**

Ja. Eine Präsentation kann mehrere Folienmaster‑Folien enthalten. Verwenden Sie mehrere Master, wenn verschiedene Abschnitte unterschiedliche visuelle Systeme oder Markenkennzeichnungen benötigen.

**Sollte ich Platzhalter zu einer Masterfolie oder zu einer Layoutfolie hinzufügen?**

In den meisten Fällen fügen Sie Platzhalter zu Layoutfolien hinzu. Legen Sie gemeinsame visuelle Elemente und Formatierungen auf die Masterfolie, und setzen Sie Inhalts‑Platzhalter auf die Layouts, die die normalen Folien verwenden.

**Kann ich eine Masterfolie löschen, die noch verwendet wird?**

Nein. Eine Masterfolie, die abhängige Folien hat, kann nicht sicher direkt entfernt werden. Verschieben Sie zuerst diese Folien zu Layouts unter einem anderen Master oder verwenden Sie eine Bereinigungs‑Methode, die nur ungenutzte Master entfernt.