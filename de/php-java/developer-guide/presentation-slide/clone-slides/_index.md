---
title: Folien einer Präsentation in PHP klonen
linktitle: Folien klonen
type: docs
weight: 35
url: /de/php-java/clone-slides/
keywords:
- Folien klonen
- Folien kopieren
- Folien speichern
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Duplizieren Sie PowerPoint-Folien schnell mit Aspose.Slides für PHP. Folgen Sie unseren klaren Code-Beispielen, um die PPT-Erstellung in Sekunden zu automatisieren und manuelle Arbeit zu vermeiden."
---

## **Folien in einer Präsentation klonen**
Klonen ist der Vorgang, eine exakte Kopie oder Nachbildung von etwas zu erstellen. Aspose.Slides for PHP via Java ermöglicht es außerdem, eine beliebige Folie zu kopieren oder zu klonen und diesen Klon in die aktuelle oder eine andere geöffnete Präsentation einzufügen. Der Vorgang des Folienklonens erzeugt eine neue Folie, die von Entwicklern geändert werden kann, ohne die Originalfolie zu verändern. Es gibt mehrere mögliche Methoden, eine Folie zu klonen:

- Klon am Ende innerhalb einer Präsentation.
- Klon an anderer Position innerhalb der Präsentation.
- Klon am Ende in einer anderen Präsentation.
- Klon an anderer Position in einer anderen Präsentation.
- Klon an einer bestimmten Position in einer anderen Präsentation.

In Aspose.Slides for PHP via Java stellt die (eine Sammlung von [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/Slide)-Objekten), die vom [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Objekt bereitgestellt wird, die Methoden [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone) und [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#insertClone) zur Verfügung, um die oben genannten Arten des Folienklonens auszuführen.

## **Eine Folie am Ende einer Präsentation klonen**
Wenn Sie eine Folie klonen und anschließend im selben Präsentations‑Datei am Ende der vorhandenen Folien verwenden möchten, verwenden Sie die [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone)-Methode gemäß den unten aufgeführten Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.
1. Rufen Sie das [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getSlides)-Objekt ab, indem Sie auf die von der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse bereitgestellte Folien‑Sammlung zugreifen.
1. Rufen Sie die [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone)-Methode des [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getSlides)-Objekts auf und übergeben Sie die zu klonende Folie als Parameter an die [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone)-Methode.
1. Schreiben Sie die geänderte Präsentationsdatei.

Im nachfolgenden Beispiel haben wir eine Folie (die an erster Position – Index 0 – der Präsentation liegt) an das Ende der Präsentation geklont.
```php
  # Instanziiere die Presentation-Klasse, die eine Präsentationsdatei repräsentiert
  $pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
  try {
    # Klone die gewünschte Folie an das Ende der Foliensammlung in derselben Präsentation
    $slds = $pres->getSlides();
    $slds->addClone($pres->getSlides()->get_Item(0));
    # Speichere die geänderte Präsentation auf dem Datenträger
    $pres->save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **Eine Folie an anderer Position innerhalb einer Präsentation klonen**
Wenn Sie eine Folie klonen und anschließend im selben Präsentations‑Datei, jedoch an einer anderen Position, verwenden möchten, nutzen Sie die [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#insertClone)-Methode:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.
1. Rufen Sie das [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection)-Objekt ab, indem Sie auf die [**Slides**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getSlides)-Sammlung der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse zugreifen.
1. Rufen Sie die [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#insertClone)-Methode des [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getSlides)-Objekts auf und übergeben Sie die zu klonende Folie zusammen mit dem Index für die neue Position als Parameter an die [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#insertClone)-Methode.
1. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Im nachfolgenden Beispiel haben wir eine Folie (die an Index 0 – Position 1 – der Präsentation liegt) auf Index 1 – Position 2 – der Präsentation geklont.
```php
  # Instanziiere die Presentation-Klasse, die eine Präsentationsdatei repräsentiert
  $pres = new Presentation("CloneWithInSamePresentation.pptx");
  try {
    # Klone die gewünschte Folie an das Ende der Foliensammlung in derselben Präsentation
    $slds = $pres->getSlides();
    # Klone die gewünschte Folie an den angegebenen Index in derselben Präsentation
    $slds->insertClone(2, $pres->getSlides()->get_Item(1));
    # Speichere die geänderte Präsentation auf dem Datenträger
    $pres->save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **Eine Folie am Ende einer anderen Präsentation klonen**
Wenn Sie eine Folie aus einer Präsentation klonen und in einer anderen Präsentationsdatei am Ende der vorhandenen Folien verwenden möchten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse, die die Quellpräsentation enthält, aus der die Folie geklont werden soll.
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse, die die Zielpräsentation enthält, zu der die Folie hinzugefügt werden soll.
1. Rufen Sie das [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection)-Objekt ab, indem Sie auf die [**Slides**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getSlides)-Sammlung des Präsentations‑Objekts der Zielpräsentation zugreifen.
1. Rufen Sie die [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone)-Methode des [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getSlides)-Objekts auf und übergeben Sie die Folie aus der Quellpräsentation als Parameter an die [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone)-Methode.
1. Schreiben Sie die geänderte Zielpräsentationsdatei.

Im nachfolgenden Beispiel haben wir eine Folie (aus dem ersten Index der Quellpräsentation) an das Ende der Zielpräsentation geklont.
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
      # Speichere die Zielpräsentation auf dem Datenträger
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```


## **Eine Folie an anderer Position in einer anderen Präsentation klonen**
Wenn Sie eine Folie aus einer Präsentation klonen und in einer anderen Präsentationsdatei an einer bestimmten Position verwenden möchten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse, die die Quellpräsentation enthält, aus der die Folie geklont werden soll.
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse, die die Zielpräsentation enthält, zu der die Folie hinzugefügt werden soll.
1. Rufen Sie die [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getSlides)-Klasse ab, indem Sie auf die Slides‑Sammlung des Präsentations‑Objekts der Zielpräsentation zugreifen.
1. Rufen Sie die [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#insertClone)-Methode des [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getSlides)-Objekts auf und übergeben Sie die Folie aus der Quellpräsentation zusammen mit der gewünschten Position als Parameter an die [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#insertClone)-Methode.
1. Schreiben Sie die geänderte Zielpräsentationsdatei.

Im nachfolgenden Beispiel haben wir eine Folie (aus dem Index 0 der Quellpräsentation) auf Index 1 (Position 2) der Zielpräsentation geklont.
```php
  # Präsentationsklasse instanziieren, um die Quellpräsentationsdatei zu laden
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Präsentationsklasse für die Ziel-PPTX (wo die Folie geklont werden soll) instanziieren
    $destPres = new Presentation();
    try {
      # Gewünschte Folie aus der Quellpräsentation an das Ende der Foliensammlung in der Zielpräsentation klonen
      $slds = $destPres->getSlides();
      $slds->insertClone(2, $srcPres->getSlides()->get_Item(0));
      # Zielpräsentation auf dem Datenträger speichern
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```


## **Eine Folie an einer spezifischen Position in einer anderen Präsentation klonen**
Wenn Sie eine Folie mit einer Masterfolie aus einer Präsentation klonen und in einer anderen Präsentation verwenden möchten, müssen Sie zunächst die gewünschte Masterfolie aus der Quellpräsentation in die Zielpräsentation klonen. Anschließend verwenden Sie diese Masterfolie zum Klonen der Folie mit Masterfolie. Die [**addClone(Slide, MasterSlide, boolean)**](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/addclone/) erwartet eine Masterfolie aus der Zielpräsentation und nicht aus der Quellpräsentation. Gehen Sie dafür wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse, die die Quellpräsentation enthält, aus der die Folie geklont werden soll.
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse, die die Zielpräsentation enthält, zu der die Folie geklont werden soll.
1. Greifen Sie auf die zu klonende Folie zusammen mit deren Masterfolie zu.
1. Instanziieren Sie die [MasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlideCollection)-Klasse, indem Sie auf die Masters‑Sammlung des [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Objekts der Zielpräsentation zugreifen.
1. Rufen Sie die [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone)-Methode des [MasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlideCollection)-Objekts auf und übergeben Sie die zu klonende Masterfolie aus der Quell‑PPTX als Parameter an die [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone)-Methode.
1. Instanziieren Sie die [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getSlides)-Klasse, indem Sie die Referenz auf die Slides‑Sammlung des [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Objekts der Zielpräsentation setzen.
1. Rufen Sie die [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone)-Methode des [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getSlides)-Objekts auf und übergeben Sie die zu klonende Folie aus der Quellpräsentation sowie die Masterfolie als Parameter an die [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone)-Methode.
1. Schreiben Sie die geänderte Zielpräsentationsdatei.

Im nachfolgenden Beispiel haben wir eine Folie mit Master (die an Index 0 der Quellpräsentation liegt) an das Ende der Zielpräsentation geklont, wobei die Masterfolie aus der Quellfolie verwendet wurde.
```php
  # Instanziiere die Presentation-Klasse, um die Quellpräsentationsdatei zu laden
  $srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
  try {
    # Instanziiere die Presentation-Klasse für die Zielpräsentation (in die die Folie geklont werden soll)
    $destPres = new Presentation();
    try {
      # Instanziiere ISlide aus der Foliensammlung der Quellpräsentation zusammen mit
      # Masterfolie
      $SourceSlide = $srcPres->getSlides()->get_Item(0);
      $SourceMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Klone die gewünschte Masterfolie aus der Quellpräsentation in die Sammlung der Master in der
      # Zielpräsentation
      $masters = $destPres->getMasters();
      $DestMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Klone die gewünschte Masterfolie aus der Quellpräsentation in die Sammlung der Master in der
      # Zielpräsentation
      $iSlide = $masters->addClone($SourceMaster);
      # Klone die gewünschte Folie aus der Quellpräsentation mit dem gewünschten Master an das Ende der
      # Foliensammlung in der Zielpräsentation
      $slds = $destPres->getSlides();
      $slds->addClone($SourceSlide, $iSlide, true);
      # Speichere die Zielpräsentation auf dem Datenträger
      $destPres->save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```


## **Eine Folie am Ende eines angegebenen Abschnitts klonen**
Wenn Sie eine Folie klonen und anschließend im selben Präsentations‑Datei, jedoch in einem anderen Abschnitt, verwenden möchten, benutzen Sie die [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone)-Methode der [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection)-Klasse. Aspose.Slides for PHP via Java ermöglicht es, eine Folie aus dem ersten Abschnitt zu klonen und diesen Klon in den zweiten Abschnitt derselben Präsentation einzufügen.

Der folgende Code‑Snippet zeigt, wie Sie eine Folie klonen und den geklonten Folien‑Eintrag in einen angegebenen Abschnitt einfügen.
```php
  $presentation = new Presentation();
  try {
    $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 50, 300, 100);
    $presentation->getSections()->addSection("Section 1", $presentation->getSlides()->get_Item(0));
    $section2 = $presentation->getSections()->appendEmptySection("Section 2");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0), $section2);
    # Speichere die Zielpräsentation auf dem Datenträger
    $presentation->save($dataDir . "CloneSlideIntoSpecifiedSection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **FAQ**

**Werden Sprechernotizen und Prüferkommentare geklont?**

Ja. Die Notizenseite und Prüferkommentare werden im Klon übernommen. Wenn Sie sie nicht benötigen, [entfernen Sie sie](/slides/de/php-java/presentation-notes/) nach dem Einfügen.

**Wie werden Diagramme und deren Datenquellen behandelt?**

Das Diagramm‑Objekt, die Formatierung und eingebettete Daten werden kopiert. Wenn das Diagramm mit einer externen Quelle verknüpft war (z. B. einer OLE‑eingebetteten Arbeitsmappe), bleibt diese Verknüpfung als [OLE‑Objekt](/slides/de/php-java/manage-ole/) erhalten. Nach dem Verschieben zwischen Dateien prüfen Sie die Datenverfügbarkeit und das Aktualisierungsverhalten.

**Kann ich die Einfügeposition und Abschnitte für den Klon steuern?**

Ja. Sie können den Klon an einem bestimmten Folien‑Index einfügen und ihn in einen gewünschten [Abschnitt](/slides/de/php-java/slide-section/) verschieben. Existiert der Zielabschnitt nicht, erstellen Sie ihn zuerst und verschieben dann die Folie dorthin.