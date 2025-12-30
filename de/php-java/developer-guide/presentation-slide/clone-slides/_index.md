---
title: Folien einer Präsentation in PHP klonen
linktitle: Folien klonen
type: docs
weight: 35
url: /de/php-java/clone-slides/
keywords:
- Folien klonen
- Folie kopieren
- Folien speichern
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "PowerPoint-Folien schnell mit Aspose.Slides für PHP duplizieren. Befolgen Sie unsere klaren Code-Beispiele, um die PPT-Erstellung in Sekunden zu automatisieren und manuelle Arbeit zu vermeiden."
---

## **Folien in einer Präsentation klonen**
Klonen ist der Vorgang, eine exakte Kopie oder Replikat von etwas zu erstellen. Aspose.Slides für PHP via Java ermöglicht ebenfalls das Erstellen einer Kopie bzw. eines Klons einer beliebigen Folie und das anschließende Einfügen dieser geklonten Folie in die aktuelle oder eine andere geöffnete Präsentation. Der Vorgang des Folienklonens erzeugt eine neue Folie, die von Entwicklern geändert werden kann, ohne die Originalfolie zu verändern. Es gibt mehrere Möglichkeiten, eine Folie zu klonen:

- Klonen am Ende innerhalb einer Präsentation.
- Klonen an einer anderen Position innerhalb einer Präsentation.
- Klonen am Ende in einer anderen Präsentation.
- Klonen an einer anderen Position in einer anderen Präsentation.
- Klonen an einer bestimmten Position in einer anderen Präsentation.

In Aspose.Slides für PHP via Java stellt (eine Sammlung von [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide) Objekten), die vom [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Objekt bereitgestellt wird, die Methoden [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) und [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) zur Verfügung, um die oben genannten Arten des Folienklonens durchzuführen

## **Eine Folie am Ende einer Präsentation klonen**
Wenn Sie eine Folie klonen und anschließend innerhalb derselben Präsentationsdatei am Ende der vorhandenen Folien verwenden möchten, verwenden Sie die Methode [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) , gemäß den unten aufgeführten Schritten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Instanziieren Sie die Klasse [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) , indem Sie auf die von dem Objekt [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) bereitgestellte Slides‑Sammlung verweisen.
1. Rufen Sie die von dem Objekt [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) bereitgestellte Methode [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) auf und übergeben Sie die zu klonende Folie als Parameter an die Methode [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Schreiben Sie die geänderte Präsentationsdatei.

Im nachstehenden Beispiel haben wir eine Folie (die sich an der ersten Position – Index 0 – der Präsentation befindet) an das Ende der Präsentation geklont.
```php
  # Instanziiere Presentation-Klasse, die eine Präsentationsdatei darstellt
  $pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
  try {
    # Klone die gewünschte Folie an das Ende der Foliensammlung in derselben Präsentation
    $slds = $pres->getSlides();
    $slds->addClone($pres->getSlides()->get_Item(0));
    # Schreibe die modifizierte Präsentation auf die Festplatte
    $pres->save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **Eine Folie an einer anderen Position innerhalb einer Präsentation klonen**
Wenn Sie eine Folie klonen und anschließend innerhalb derselben Präsentationsdatei, jedoch an einer anderen Position verwenden möchten, verwenden Sie die Methode [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) :

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Instanziieren Sie die Klasse, indem Sie auf die von dem Objekt [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) bereitgestellte **Slides**‑Sammlung verweisen.
1. Rufen Sie die von dem Objekt [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) bereitgestellte Methode [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) auf und übergeben Sie die zu klonende Folie zusammen mit dem Index für die neue Position als Parameter an die Methode [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) .
1. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Im nachstehenden Beispiel haben wir eine Folie (die sich am Index 0 – Position 1 – der Präsentation befindet) an Index 1 – Position 2 – der Präsentation geklont.
```php
  # Instanziiere Presentation-Klasse die eine Präsentationsdatei darstellt
  $pres = new Presentation("CloneWithInSamePresentation.pptx");
  try {
    # Klone die gewünschte Folie an das Ende der Foliensammlung in derselben Präsentation
    $slds = $pres->getSlides();
    # Klone die gewünschte Folie an den angegebenen Index in derselben Präsentation
    $slds->insertClone(2, $pres->getSlides()->get_Item(1));
    # Schreibe die modifizierte Präsentation auf die Festplatte
    $pres->save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **Eine Folie am Ende einer anderen Präsentation klonen**
Wenn Sie eine Folie aus einer Präsentation klonen und in einer anderen Präsentationsdatei am Ende der vorhandenen Folien verwenden müssen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) , die die Präsentation enthält, aus der die Folie geklont werden soll.
1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) , die die Zielpräsentation enthält, zu der die Folie hinzugefügt werden soll.
1. Instanziieren Sie die Klasse [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection) , indem Sie auf die von dem Presentation‑Objekt der Zielpräsentation bereitgestellte **Slides**‑Sammlung verweisen.
1. Rufen Sie die von dem Objekt [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) bereitgestellte Methode [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) auf und übergeben Sie die Folie aus der Quellpräsentation als Parameter an die Methode [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) .
1. Schreiben Sie die geänderte Zielpräsentationsdatei.

Im nachstehenden Beispiel haben wir eine Folie (aus dem ersten Index der Quellpräsentation) an das Ende der Zielpräsentation geklont.
```php
  # Instanziiere Presentation-Klasse, um die Quellpräsentationsdatei zu laden
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Instanziiere Presentation-Klasse für das Ziel-PPTX (wo die Folie geklont werden soll)
    $destPres = new Presentation();
    try {
      # Klone die gewünschte Folie aus der Quellpräsentation an das Ende der Foliensammlung im Zielpräsentation
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
Wenn Sie eine Folie aus einer Präsentation klonen und in einer anderen Präsentationsdatei an einer bestimmten Position verwenden müssen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) , die die Quellpräsentation enthält, aus der die Folie geklont werden soll.
1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) , die die Präsentation enthält, zu der die Folie hinzugefügt werden soll.
1. Instanziieren Sie die Klasse [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) , indem Sie auf die von dem Presentation‑Objekt der Zielpräsentation bereitgestellte Slides‑Sammlung verweisen.
1. Rufen Sie die von dem Objekt [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) bereitgestellte Methode [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) auf und übergeben Sie die Folie aus der Quellpräsentation zusammen mit der gewünschten Position als Parameter an die Methode [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) .
1. Schreiben Sie die geänderte Zielpräsentationsdatei.

Im nachstehenden Beispiel haben wir eine Folie (aus dem Index 0 der Quellpräsentation) an Index 1 (Position 2) der Zielpräsentation geklont.
```php
  # Instanziiere Presentation-Klasse, um die Quellpräsentationsdatei zu laden
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Instanziiere Presentation-Klasse für das Ziel-PPTX (in das die Folie geklont werden soll)
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
Wenn Sie eine Folie inklusive Masterfolie aus einer Präsentation klonen und in einer anderen Präsentation verwenden müssen, müssen Sie zuerst die gewünschte Masterfolie von der Quellpräsentation in die Zielpräsentation klonen. Anschließend verwenden Sie diese Masterfolie zum Klonen der Folie mit Masterfolie. Die Methode [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) erwartet eine Masterfolie aus der Zielpräsentation und nicht aus der Quellpräsentation. Um die Folie mit Master zu klonen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) , die die Quellpräsentation enthält, aus der die Folie geklont werden soll.
1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) , die die Zielpräsentation enthält, zu der die Folie geklont werden soll.
1. Greifen Sie auf die zu klonende Folie zusammen mit der Masterfolie zu.
1. Instanziieren Sie die Klasse [IMasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlideCollection) , indem Sie auf die von dem Objekt [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) der Zielpräsentation bereitgestellte Masters‑Sammlung verweisen.
1. Rufen Sie die von dem Objekt [IMasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlideCollection) bereitgestellte Methode [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) auf und übergeben Sie die Masterfolie aus der Quell‑PPTX, die geklont werden soll, als Parameter an die Methode [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) .
1. Instanziieren Sie die Klasse [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) , indem Sie die Referenz auf die von dem Objekt [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) der Zielpräsentation bereitgestellte Slides‑Sammlung setzen.
1. Rufen Sie die von dem Objekt [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) bereitgestellte Methode [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) auf und übergeben Sie die zu klonende Folie aus der Quellpräsentation sowie die Masterfolie als Parameter an die Methode [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) .
1. Schreiben Sie die geänderte Zielpräsentationsdatei.

Im nachstehenden Beispiel haben wir eine Folie mit einer Masterfolie (die sich am Index 0 der Quellpräsentation befindet) an das Ende der Zielpräsentation geklont, wobei die Masterfolie der Quellfolie verwendet wurde.
```php
  # Instanziiere Presentation-Klasse, um die Quellpräsentationsdatei zu laden
  $srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
  try {
    # Instanziiere Presentation-Klasse für die Zielpräsentation (wo die Folie geklont werden soll)
    $destPres = new Presentation();
    try {
      # Instanziiere ISlide aus der Folienkollektion der Quellpräsentation zusammen mit
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
      # Folienkollektion in der Zielpräsentation
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
Wenn Sie eine Folie klonen und anschließend innerhalb derselben Präsentationsdatei, jedoch in einem anderen Abschnitt verwenden möchten, verwenden Sie die [**addClone**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) Methode, die vom Interface [**ISlideCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection) bereitgestellt wird. Aspose.Slides für PHP via Java ermöglicht das Klonen einer Folie aus dem ersten Abschnitt und das anschließende Einfügen dieser geklonten Folie in den zweiten Abschnitt derselben Präsentation.

Der folgende Code‑Abschnitt zeigt, wie Sie eine Folie klonen und die geklonte Folie in einen angegebenen Abschnitt einfügen.
```php
  $presentation = new Presentation();
  try {
    $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 50, 300, 100);
    $presentation->getSections()->addSection("Section 1", $presentation->getSlides()->get_Item(0));
    $section2 = $presentation->getSections()->appendEmptySection("Section 2");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0), $section2);
    # Speichere die Zielpräsentation auf die Festplatte
    $presentation->save($dataDir . "CloneSlideIntoSpecifiedSection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **FAQ**

**Werden Sprecher‑Notizen und Reviewer‑Kommentare geklont?**

Ja. Die Notizenseite und Review‑Kommentare werden in den Klon übernommen. Wenn Sie sie nicht benötigen, [entfernen Sie sie](/slides/de/php-java/presentation-notes/) nach dem Einfügen.

**Wie werden Diagramme und deren Datenquellen behandelt?**

Das Diagrammobjekt, die Formatierung und die eingebetteten Daten werden kopiert. Wenn das Diagramm mit einer externen Quelle verknüpft war (z. B. einer OLE‑eingebetteten Arbeitsmappe), bleibt diese Verknüpfung als [OLE‑Objekt](/slides/de/php-java/manage-ole/) erhalten. Nach dem Verschieben zwischen Dateien sollten Sie die Datenverfügbarkeit und das Aktualisierungsverhalten prüfen.

**Kann ich die Einfügeposition und die Abschnitte für den Klon steuern?**

Ja. Sie können den Klon an einem bestimmten Folien‑Index einfügen und ihn in einen gewählten [Abschnitt](/slides/de/php-java/slide-section/) platzieren. Wenn der Zielabschnitt nicht existiert, erstellen Sie ihn zuerst und verschieben Sie dann die Folie dorthin.