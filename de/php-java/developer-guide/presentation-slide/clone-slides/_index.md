---
title: Folien in PHP klonen
linktitle: Folien klonen
type: docs
weight: 35
url: /de/php-java/clone-slides/
keywords:
- Folie klonen
- Folie kopieren
- Folie speichern
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Duplizieren Sie PowerPoint‑Folien schnell mit Aspose.Slides für PHP. Folgen Sie unseren klaren Codebeispielen, um PPT‑Erstellung in Sekunden zu automatisieren und manuelle Arbeit zu vermeiden."
---
## **Einführung**

Klonen ist der Vorgang, eine exakte Kopie oder Replik eines Objekts zu erstellen. Aspose.Slides für PHP via Java ermöglicht ebenfalls das Erstellen einer Kopie bzw. eines Klons einer beliebigen Folie und das anschließende Einfügen dieser geklonten Folie in die aktuelle oder eine andere geöffnete Präsentation. Der Vorgang des Folienklonens erzeugt eine neue Folie, die von Entwicklern geändert werden kann, ohne die Originalfolie zu verändern. Es gibt mehrere Möglichkeiten, eine Folie zu klonen:

- Klonen am Ende innerhalb einer Präsentation.
- Klonen an einer anderen Position innerhalb einer Präsentation.
- Klonen am Ende in einer anderen Präsentation.
- Klonen an einer anderen Position in einer anderen Präsentation.
- Klonen an einer bestimmten Position in einer anderen Präsentation.

In Aspose.Slides für PHP via Java stellt (eine Sammlung von [Folie](https://reference.aspose.com/slides/de/php-java/aspose.slides/Slide)-Objekten), die vom [Präsentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/Presentation)-Objekt bereitgestellt werden, die Methoden [addClone](https://reference.aspose.com/slides/de/php-java/aspose.slides/SlideCollection/#addClone) und [insertClone](https://reference.aspose.com/slides/de/php-java/aspose.slides/SlideCollection/#insertClone) zur Durchführung der oben genannten Arten des Folienklonens zur Verfügung.

## **Eine Folie am Ende einer Präsentation klonen**
Wenn Sie eine Folie klonen und sie anschließend innerhalb derselben Präsentationsdatei am Ende der vorhandenen Folien verwenden möchten, verwenden Sie die Methode [addClone](https://reference.aspose.com/slides/de/php-java/aspose.slides/SlideCollection/#addClone) gemäß den unten aufgeführten Schritten:

1. Erstellen Sie eine Instanz der Klasse [Präsentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/Presentation).
1. Rufen Sie das Objekt [SlideCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/Presentation/#getSlides) ab, indem Sie auf die Folienkollektion zugreifen, die vom [Präsentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/Presentation)-Objekt bereitgestellt wird.
1. Rufen Sie die Methode [addClone](https://reference.aspose.com/slides/de/php-java/aspose.slides/SlideCollection/#addClone) des [SlideCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/Presentation/#getSlides)-Objekts auf und übergeben Sie die zu klonende Folie als Parameter an die Methode [addClone](https://reference.aspose.com/slides/de/php-java/aspose.slides/SlideCollection/#addClone).
1. Speichern Sie die geänderte Präsentationsdatei.

Im nachfolgenden Beispiel haben wir eine Folie (die an der ersten Position – Index 0 – der Präsentation liegt) an das Ende der Präsentation geklont.

```php
  # Instanziiere die Presentation‑Klasse, die eine Präsentationsdatei repräsentiert
  $pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
  try {
    # Klone die gewünschte Folie an das Ende der Foliensammlung in derselben Präsentation
    $slds = $pres->getSlides();
    $slds->addClone($pres->getSlides()->get_Item(0));
    # Schreibe die geänderte Präsentation auf die Festplatte
    $pres->save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Eine Folie an einer anderen Position innerhalb einer Präsentation klonen**
Wenn Sie eine Folie klonen und sie anschließend innerhalb derselben Präsentationsdatei, jedoch an einer anderen Position verwenden möchten, nutzen Sie die Methode [insertClone](https://reference.aspose.com/slides/de/php-java/aspose.slides/SlideCollection/#insertClone):

1. Erstellen Sie eine Instanz der Klasse [Präsentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/Presentation).
1. Rufen Sie das Objekt [SlideCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/SlideCollection) ab, indem Sie die Sammlung [**Folien**](https://reference.aspose.com/slides/de/php-java/aspose.slides/Presentation/#getSlides) referenzieren, die vom [Präsentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/Presentation)-Objekt bereitgestellt wird.
1. Rufen Sie die Methode [insertClone](https://reference.aspose.com/slides/de/php-java/aspose.slides/SlideCollection/#insertClone) des [SlideCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/Presentation/#getSlides)-Objekts auf und übergeben Sie die zu klonende Folie zusammen mit dem Index für die neue Position als Parameter an die Methode [insertClone](https://reference.aspose.com/slides/de/php-java/aspose.slides/SlideCollection/#insertClone).
1. Speichern Sie die geänderte Präsentation als PPTX-Datei.

Im nachfolgenden Beispiel haben wir eine Folie (die beim Index 0 – Position 1 – der Präsentation liegt) auf Index 1 – Position 2 – der Präsentation geklont.

```php
  # Instanziiere die Presentation-Klasse, die eine Präsentationsdatei darstellt
  $pres = new Presentation("CloneWithInSamePresentation.pptx");
  try {
    # Klone die gewünschte Folie an das Ende der Foliensammlung in derselben Präsentation
    $slds = $pres->getSlides();
    # Klone die gewünschte Folie an den angegebenen Index in derselben Präsentation
    $slds->insertClone(2, $pres->getSlides()->get_Item(1));
    # Schreibe die geänderte Präsentation auf die Festplatte
    $pres->save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Eine Folie am Ende einer anderen Präsentation klonen**
Wenn Sie eine Folie aus einer Präsentation klonen und sie in einer anderen Präsentationsdatei am Ende der vorhandenen Folien verwenden müssen:

1. Erstellen Sie eine Instanz der Klasse [Präsentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/Presentation), die die Quellpräsentation enthält, aus der die Folie geklont werden soll.
1. Erstellen Sie eine Instanz der Klasse [Präsentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/Presentation), die die Zielpräsentation enthält, zu der die Folie hinzugefügt werden soll.
1. Rufen Sie das Objekt [SlideCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/SlideCollection) ab, indem Sie die Sammlung [**Folien**](https://reference.aspose.com/slides/de/php-java/aspose.slides/Presentation/#getSlides) referenzieren, die vom Präsentationsobjekt der Zielpräsentation bereitgestellt wird.
1. Rufen Sie die Methode [addClone](https://reference.aspose.com/slides/de/php-java/aspose.slides/SlideCollection/#addClone) des [SlideCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/Presentation/#getSlides)-Objekts auf und übergeben Sie die Folie aus der Quellpräsentation als Parameter an die Methode [addClone](https://reference.aspose.com/slides/de/php-java/aspose.slides/SlideCollection/#addClone).
1. Speichern Sie die geänderte Zielpräsentationsdatei.

Im nachfolgenden Beispiel haben wir eine Folie (vom ersten Index der Quellpräsentation) an das Ende der Zielpräsentation geklont.

```php
  # Instanziiere die Presentation-Klasse, um die Quellpräsentationsdatei zu laden
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Instanziiere die Presentation-Klasse für die Ziel-PPTX (wo die Folie geklont werden soll)
    $destPres = new Presentation();
    try {
      # Klone die gewünschte Folie aus der Quellpräsentation an das Ende der Foliensammlung in der Zielpräsentation
      $slds = $destPres->getSlides();
      $slds->addClone($srcPres->getSlides()->get_Item(0));
      # Schreibe die Zielpräsentation auf die Festplatte
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Eine Folie an einer anderen Position in einer anderen Präsentation klonen**
Wenn Sie eine Folie aus einer Präsentation klonen und sie in einer anderen Präsentationsdatei an einer bestimmten Position verwenden müssen:

1. Erstellen Sie eine Instanz der Klasse [Präsentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/Presentation), die die Quellpräsentation enthält, aus der die Folie geklont werden soll.
1. Erstellen Sie eine Instanz der Klasse [Präsentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/Presentation), die die Zielpräsentation enthält, zu der die Folie hinzugefügt werden soll.
1. Rufen Sie die Klasse [SlideCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/Presentation/#getSlides) ab, indem Sie die Foliensammlung referenzieren, die vom Präsentationsobjekt der Zielpräsentation bereitgestellt wird.
1. Rufen Sie die Methode [insertClone](https://reference.aspose.com/slides/de/php-java/aspose.slides/SlideCollection/#insertClone) des [SlideCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/Presentation/#getSlides)-Objekts auf und übergeben Sie die Folie aus der Quellpräsentation zusammen mit der gewünschten Position als Parameter an die Methode [insertClone](https://reference.aspose.com/slides/de/php-java/aspose.slides/SlideCollection/#insertClone).
1. Speichern Sie die geänderte Zielpräsentationsdatei.

Im nachfolgenden Beispiel haben wir eine Folie (vom Index 0 der Quellpräsentation) auf Index 1 (Position 2) der Zielpräsentation geklont.

```php
  # Instanziiere die Presentation-Klasse, um die Quellpräsentationsdatei zu laden
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Instanziiere die Presentation-Klasse für die Ziel-PPTX (wo die Folie geklont werden soll)
    $destPres = new Presentation();
    try {
      # Klone die gewünschte Folie aus der Quellpräsentation an das Ende der Foliensammlung in der Zielpräsentation
      $slds = $destPres->getSlides();
      $slds->insertClone(2, $srcPres->getSlides()->get_Item(0));
      # Schreibe die Zielpräsentation auf die Festplatte
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Eine Folie an einer bestimmten Position in einer anderen Präsentation klonen**
Wenn Sie eine Folie mit einer Masterfolie aus einer Präsentation klonen und in einer anderen Präsentation verwenden müssen, müssen Sie zuerst die gewünschte Masterfolie von der Quellpräsentation in die Zielpräsentation klonen. Anschließend verwenden Sie diese Masterfolie, um die Folie mit Masterfolie zu klonen. Die Methode [**addClone(Slide, MasterSlide, boolean)**](https://reference.aspose.com/slides/de/php-java/aspose.slides/slidecollection/addclone/) erwartet eine Masterfolie aus der Zielpräsentation statt aus der Quellpräsentation. Um die Folie mit einem Master zu klonen, befolgen Sie bitte die nachstehenden Schritte:

1. Erstellen Sie eine Instanz der Klasse [Präsentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/Presentation), die die Quellpräsentation enthält, aus der die Folie geklont werden soll.
1. Erstellen Sie eine Instanz der Klasse [Präsentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/Presentation), die die Zielpräsentation enthält, zu der die Folie geklont werden soll.
1. Greifen Sie auf die zu klonende Folie zusammen mit der Masterfolie zu.
1. Instanziieren Sie die Klasse [MasterSlideCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/MasterSlideCollection), indem Sie die Masters‑Sammlung referenzieren, die vom [Präsentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/Presentation)-Objekt der Zielpräsentation bereitgestellt wird.
1. Rufen Sie die Methode [addClone](https://reference.aspose.com/slides/de/php-java/aspose.slides/SlideCollection/#addClone) des [MasterSlideCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/MasterSlideCollection)-Objekts auf und übergeben Sie den Master aus der Quell‑PPTX, der geklont werden soll, als Parameter an die Methode [addClone](https://reference.aspose.com/slides/de/php-java/aspose.slides/SlideCollection/#addClone).
1. Instanziieren Sie die Klasse [SlideCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/Presentation/#getSlides), indem Sie die Referenz auf die Folien‑Sammlung setzen, die vom [Präsentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/Presentation)-Objekt der Zielpräsentation bereitgestellt wird.
1. Rufen Sie die Methode [addClone](https://reference.aspose.com/slides/de/php-java/aspose.slides/SlideCollection/#addClone) des [SlideCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/Presentation/#getSlides)-Objekts auf und übergeben Sie die zu klonende Folie aus der Quellpräsentation sowie die Masterfolie als Parameter an die Methode [addClone](https://reference.aspose.com/slides/de/php-java/aspose.slides/SlideCollection/#addClone).
1. Speichern Sie die geänderte Zielpräsentationsdatei.

Im nachfolgenden Beispiel haben wir eine Folie mit einem Master (die beim Index 0 der Quellpräsentation liegt) an das Ende der Zielpräsentation geklont, wobei ein Master aus der Quellfolie verwendet wurde.

```php
  # Instanziiere die Presentation-Klasse, um die Quellpräsentationsdatei zu laden
  $srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
  try {
    # Instanziiere die Presentation-Klasse für die Zielpräsentation (wo die Folie geklont werden soll)
    $destPres = new Presentation();
    try {
      # Instanziiere ISlide aus der Sammlung von Folien in der Quellpräsentation zusammen mit
      # Masterfolie
      $SourceSlide = $srcPres->getSlides()->get_Item(0);
      $SourceMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Klone die gewünschte Masterfolie aus der Quellpräsentation in die Sammlung von Masters in der
      # Zielpräsentation
      $masters = $destPres->getMasters();
      $DestMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Klone die gewünschte Masterfolie aus der Quellpräsentation in die Sammlung von Masters in der
      # Zielpräsentation
      $iSlide = $masters->addClone($SourceMaster);
      # Klone die gewünschte Folie aus der Quellpräsentation mit dem gewünschten Master an das Ende der
      # Sammlung von Folien in der Zielpräsentation
      $slds = $destPres->getSlides();
      $slds->addClone($SourceSlide, $iSlide, true);
      # Speichere die Zielpräsentation auf die Festplatte
      $destPres->save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Eine Folie am Ende eines angegebenen Abschnitts klonen**
Wenn Sie eine Folie klonen und sie anschließend innerhalb derselben Präsentationsdatei, jedoch in einem anderen Abschnitt verwenden möchten, verwenden Sie die Methode [addClone](https://reference.aspose.com/slides/de/php-java/aspose.slides/SlideCollection/#addClone) des [SlideCollection]-Klasse. Aspose.Slides für PHP via Java ermöglicht das Klonen einer Folie aus dem ersten Abschnitt und das anschließende Einfügen dieser geklonten Folie in den zweiten Abschnitt derselben Präsentation.

Der folgende Codeabschnitt zeigt, wie Sie eine Folie klonen und die geklonte Folie in einen angegebenen Abschnitt einfügen.

```php
  $presentation = new Presentation();
  try {
    $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 50, 300, 100);
    $presentation->getSections()->addSection("Section 1", $presentation->getSlides()->get_Item(0));
    $section2 = $presentation->getSections()->appendEmptySection("Section 2");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0), $section2);
    # Speichere die Zielpräsentation auf die Festplatte
    $presentation->save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Entsprechende Foliengröße sicherstellen**

Beim Klonen von Folien in eine andere Präsentation stellen Sie sicher, dass die Zielpräsentation dieselbe Foliengröße wie die Quellpräsentation hat. Wenn die Foliengrößen unterschiedlich sind, skaliert Aspose.Slides die geklonten Formen nicht automatisch – ihre ursprünglichen Koordinaten und Abmessungen bleiben erhalten, was dazu führen kann, dass der Inhalt nicht ausgerichtet ist oder über die Folienränder hinausgeht.

Sie können die Foliengröße der Zielpräsentation vor dem Klonen von Master und Folie an die Quelle anpassen:

```php
$sourceSize = $sourcePresentation->getSlideSize()->getSize();

$targetPresentation->getSlideSize()->setSize(
    $sourceSize->getWidth(), $sourceSize->getHeight(), SlideSizeScaleType::DoNotScale);
```

Führen Sie dies vor dem Klonen des Masters und der Folie aus.

## **FAQ**

**Werden Sprecherhinweise und Überprüfungskommentare geklont?**

Ja. Die Notizenseite und die Überprüfungskommentare werden in den Klon übernommen. Wenn Sie sie nicht wünschen, [entfernen Sie sie](/slides/de/php-java/presentation-notes/) nach dem Einfügen.

**Wie werden Diagramme und deren Datenquellen behandelt?**

Das Diagrammobjekt, die Formatierung und eingebettete Daten werden kopiert. Wenn das Diagramm mit einer externen Quelle verknüpft war (z. B. einer OLE‑eingebetteten Arbeitsmappe), bleibt diese Verknüpfung als [OLE-Objekt](/slides/de/php-java/manage-ole/) erhalten. Nach dem Verschieben zwischen Dateien prüfen Sie die Verfügbarkeit der Daten und das Aktualisierungsverhalten.

**Kann ich die Einfügeposition und die Abschnitte für den Klon steuern?**

Ja. Sie können den Klon an einem bestimmten Folienindex einfügen und ihn in einen gewählten [Abschnitt](/slides/de/php-java/slide-section/) platzieren. Wenn der Zielabschnitt nicht existiert, erstellen Sie ihn zuerst und verschieben dann die Folie dorthin.