---
title: Folien Klonen
type: docs
weight: 35
url: /php-java/clone-slides/
---


## **Folien in einer Präsentation klonen**
Klonen ist der Prozess, eine exakte Kopie oder Nachbildung von etwas zu erstellen. Aspose.Slides für PHP via Java ermöglicht es auch, eine Kopie oder Klon einer beliebigen Folie zu erstellen und diese klonierte Folie dann in die aktuelle oder eine andere geöffnete Präsentation einzufügen. Der Prozess des Folienklonens erstellt eine neue Folie, die von Entwicklern ohne Änderung der Originalfolie modifiziert werden kann. Es gibt mehrere mögliche Methoden, um eine Folie zu klonen:

- Am Ende innerhalb einer Präsentation klonen.
- An einer anderen Position innerhalb der Präsentation klonen.
- Am Ende in einer anderen Präsentation klonen.
- An einer anderen Position in einer anderen Präsentation klonen.
- An einer bestimmten Position in einer anderen Präsentation klonen.

In Aspose.Slides für PHP via Java bietet eine Sammlung von [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide)-Objekten, die vom [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Objekt bereitgestellt wird, die Methoden [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) und [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-), um die oben genannten Arten des Folienklonens durchzuführen.

## **Am Ende innerhalb einer Präsentation klonen**
Wenn Sie eine Folie klonen und dann am Ende der bestehenden Folien innerhalb derselben Präsentationsdatei verwenden möchten, verwenden Sie die Methode [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) gemäß den unten aufgeführten Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.
1. Instanziieren Sie die [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--)-Klasse, indem Sie auf die von dem [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Objekt bereitgestellte Folienkollektion zugreifen.
1. Rufen Sie die Methode [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) auf, die vom [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--)-Objekt bereitgestellt wird, und übergeben Sie die Folie, die geklont werden soll, als Parameter an die Methode [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Schreiben Sie die modifizierte Präsentationsdatei.

Im nachstehenden Beispiel haben wir eine Folie (die sich an der ersten Position – Null-Index – der Präsentation befindet) zum Ende der Präsentation geklont.

```php
  # Instanziieren Sie die Präsentationsklasse, die eine Präsentationsdatei darstellt
  $pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
  try {
    # Klonen Sie die gewünschte Folie zum Ende der Sammlung von Folien in derselben Präsentation
    $slds = $pres->getSlides();
    $slds->addClone($pres->getSlides()->get_Item(0));
    # Schreiben Sie die modifizierte Präsentation auf die Festplatte
    $pres->save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **An einer anderen Position innerhalb der Präsentation klonen**
Wenn Sie eine Folie klonen und dann innerhalb derselben Präsentationsdatei, aber an einer anderen Position verwenden möchten, verwenden Sie die Methode [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-):

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.
1. Instanziieren Sie die Klasse, indem Sie auf die [**Slides**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--)-Kollektion zugreifen, die von dem [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Objekt bereitgestellt wird.
1. Rufen Sie die Methode [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) auf, die vom [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--)-Objekt bereitgestellt wird, und übergeben Sie die Folie, die geklont werden soll, zusammen mit dem Index für die neue Position als Parameter an die Methode [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
1. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Im nachstehenden Beispiel haben wir eine Folie (die sich am Null-Index – Position 1 – der Präsentation befindet) an den Index 1 – Position 2 – der Präsentation geklont.

```php
  # Instanziieren Sie die Präsentationsklasse, die eine Präsentationsdatei darstellt
  $pres = new Presentation("CloneWithInSamePresentation.pptx");
  try {
    # Klonen Sie die gewünschte Folie zum Ende der Sammlung von Folien in derselben Präsentation
    $slds = $pres->getSlides();
    # Klonen Sie die gewünschte Folie zum angegebenen Index in derselben Präsentation
    $slds->insertClone(2, $pres->getSlides()->get_Item(1));
    # Schreiben Sie die modifizierte Präsentation auf die Festplatte
    $pres->save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Am Ende in einer anderen Präsentation klonen**
Wenn Sie eine Folie aus einer Präsentation klonen und sie in einer anderen Präsentationsdatei am Ende der bestehenden Folien verwenden müssen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse, die die Präsentation enthält, aus der die Folie geklont werden soll.
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse, die die Zielpräsentation enthält, zu der die Folie hinzugefügt werden soll.
1. Instanziieren Sie die [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection)-Klasse, indem Sie auf die [**Slides**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--)-Kollektion zugreifen, die von dem Präsentationsobjekt der Zielpräsentation bereitgestellt wird.
1. Rufen Sie die Methode [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) auf, die vom [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--)-Objekt bereitgestellt wird, und übergeben Sie die Folie von der Quellpräsentation als Parameter an die Methode [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) .
1. Schreiben Sie die modifizierte Zielpräsentationsdatei.

Im nachstehenden Beispiel haben wir eine Folie (vom ersten Index der Quellpräsentation) am Ende der Zielpräsentation geklont.

```php
  # Instanziieren Sie die Präsentationsklasse, um die Quellpräsentationsdatei zu laden
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Instanziieren Sie die Präsentationsklasse für das Ziel-PPTX (wo die Folie geklont werden soll)
    $destPres = new Presentation();
    try {
      # Klonen Sie die gewünschte Folie von der Quellpräsentation zum Ende der Sammlung von Folien in der Zielpräsentation
      $slds = $destPres->getSlides();
      $slds->addClone($srcPres->getSlides()->get_Item(0));
      # Schreiben Sie die Zielpräsentation auf die Festplatte
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **An einer anderen Position in einer anderen Präsentation klonen**
Wenn Sie eine Folie aus einer Präsentation klonen und sie in einer anderen Präsentationsdatei an einer bestimmten Position verwenden müssen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse, die die Quellpräsentation enthält, aus der die Folie geklont wird.
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse, die die Präsentation enthält, zu der die Folie hinzugefügt werden soll.
1. Instanziieren Sie die [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--)-Klasse, indem Sie auf die von dem Präsentationsobjekt der Zielpräsentation bereitgestellte Folienkollektion zugreifen.
1. Rufen Sie die Methode [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) auf, die vom [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--)-Objekt bereitgestellt wird, und übergeben Sie die Folie von der Quellpräsentation zusammen mit der gewünschten Position als Parameter an die Methode [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) .
1. Schreiben Sie die modifizierte Zielpräsentationsdatei.

Im nachstehenden Beispiel haben wir eine Folie (vom Null-Index der Quellpräsentation) an den Index 1 (Position 2) der Zielpräsentation geklont.

```php
  # Instanziieren Sie die Präsentationsklasse, um die Quellpräsentationsdatei zu laden
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Instanziieren Sie die Präsentationsklasse für das Ziel-PPTX (wo die Folie geklont werden soll)
    $destPres = new Presentation();
    try {
      # Klonen Sie die gewünschte Folie von der Quellpräsentation zum Ende der Sammlung von Folien in der Zielpräsentation
      $slds = $destPres->getSlides();
      $slds->insertClone(2, $srcPres->getSlides()->get_Item(0));
      # Schreiben Sie die Zielpräsentation auf die Festplatte
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **An einer bestimmten Position in einer anderen Präsentation klonen**
Wenn Sie eine Folie mit einer Masterfolie aus einer Präsentation klonen und sie in einer anderen Präsentation verwenden müssen, müssen Sie zuerst die gewünschte Masterfolie von der Quellpräsentation in die Zielpräsentation klonen. Dann müssen Sie diese Masterfolie verwenden, um die Folie mit Masterfolie zu klonen. Die Methode [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) erwartet eine Masterfolie von der Zielpräsentation und nicht von der Quellpräsentation. Um die Folie mit einem Master zu klonen, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse, die die Quellpräsentation enthält, aus der die Folie geklont wird.
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse, die die Zielpräsentation enthält, zu der die Folie geklont werden soll.
1. Greifen Sie auf die Folie zu, die geklont werden soll, zusammen mit der Masterfolie.
1. Instanziieren Sie die [IMasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlideCollection)-Klasse, indem Sie auf die von dem [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Objekt der Zielpräsentation bereitgestellte Masters-Kollektion zugreifen.
1. Rufen Sie die Methode [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) auf, die vom [IMasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlideCollection)-Objekt bereitgestellt wird, und übergeben Sie die Masterfolie von der Quell-PPTX, die geklont werden soll, als Parameter an die Methode [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) .
1. Instanziieren Sie die [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--)-Klasse, indem Sie den Verweis auf die von dem [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Objekt der Zielpräsentation bereitgestellte Folienkollektion setzen.
1. Rufen Sie die Methode [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) auf, die vom [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--)-Objekt bereitgestellt wird, und übergeben Sie die Folie von der Quellpräsentation, die geklont werden soll, sowie die Masterfolie als Parameter an die Methode [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) .
1. Schreiben Sie die modifizierte Zielpräsentationsdatei.

Im nachstehenden Beispiel haben wir eine Folie mit einem Master (die sich am Null-Index der Quellpräsentation befindet) am Ende der Zielpräsentation unter Verwendung eines Masters von der Quellfolie geklont.

```php
  # Instanziieren Sie die Präsentationsklasse, um die Quellpräsentationsdatei zu laden
  $srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
  try {
    # Instanziieren Sie die Präsentationsklasse für die Zielpräsentation (wo die Folie geklont werden soll)
    $destPres = new Presentation();
    try {
      # Instanziieren Sie ISlide aus der Sammlung von Folien in der Quellpräsentation zusammen mit
      # Masterfolie
      $SourceSlide = $srcPres->getSlides()->get_Item(0);
      $SourceMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Klonen Sie die gewünschte Masterfolie von der Quellpräsentation in die Sammlung von Masterfolien in der
      # Zielpräsentation
      $masters = $destPres->getMasters();
      $DestMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Klonen Sie die gewünschte Masterfolie von der Quellpräsentation in die Sammlung von Masterfolien in der
      # Zielpräsentation
      $iSlide = $masters->addClone($SourceMaster);
      # Klonen Sie die gewünschte Folie von der Quellpräsentation mit der gewünschten Masterfolie zum Ende der
      # Sammlung von Folien in der Zielpräsentation
      $slds = $destPres->getSlides();
      $slds->addClone($SourceSlide, $iSlide, true);
      # Speichern Sie die Zielpräsentation auf der Festplatte
      $destPres->save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Am Ende im angegebenen Abschnitt klonen**
Wenn Sie eine Folie klonen möchten und sie dann innerhalb derselben Präsentationsdatei in einem anderen Abschnitt verwenden möchten, verwenden Sie die [**addClone**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) Methode, die von der [**ISlideCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection)-Schnittstelle bereitgestellt wird. Aspose.Slides für PHP via Java ermöglicht es Ihnen, eine Folie aus dem ersten Abschnitt zu klonen und diese klonierte Folie dann in den zweiten Abschnitt derselben Präsentation einzufügen.

Das folgende Code-Snippet zeigt Ihnen, wie Sie eine Folie klonen und die geklonte Folie in einen angegebenen Abschnitt einfügen.

```php
  $presentation = new Presentation();
  try {
    $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 50, 300, 100);
    $presentation->getSections()->addSection("Abschnitt 1", $presentation->getSlides()->get_Item(0));
    $section2 = $presentation->getSections()->appendEmptySection("Abschnitt 2");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0), $section2);
    # Speichern Sie die Zielpräsentation auf der Festplatte
    $presentation->save($dataDir . "CloneSlideIntoSpecifiedSection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```