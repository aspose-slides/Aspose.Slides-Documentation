---
title: Folienlayout
type: docs
weight: 60
url: /php-java/slide-layout/
keyword: "Foliengröße festlegen, Folienoptionen festlegen, Foliengröße angeben, Fußzeilen Sichtbarkeit, Kindfußzeile, Inhaltsskalierung, Seitenformat, Java, Aspose.Slides"
description: "PowerPoint-Foliengröße und -optionen festlegen"
---

Ein Folienlayout enthält die Platzhalterkästchen und Formatierungsinformationen für alle Inhalte, die auf einer Folie erscheinen. Das Layout bestimmt die verfügbaren Inhaltsplatzhalter und deren Position.

Folienlayouts ermöglichen es Ihnen, Präsentationen schnell zu erstellen und zu gestalten (ob einfach oder komplex). Dies sind einige der beliebtesten Folienlayouts, die in PowerPoint-Präsentationen verwendet werden:

* **Titelfolie Layout**. Dieses Layout besteht aus zwei Textplatzhaltern. Ein Platzhalter ist für den Titel und der andere für den Untertitel.
* **Titel und Inhalt Layout**. Dieses Layout enthält einen relativ kleinen Platzhalter oben für den Titel und einen größeren Platzhalter für den Kerninhalt (Diagramm, Absätze, Aufzählung, nummerierte Liste, Bilder usw.).
* **Leeres Layout**. Dieses Layout hat keine Platzhalter, sodass Sie Elemente von Grund auf neu erstellen können.

Da ein Folienmaster die oberste hierarchische Folie ist, die Informationen über Folienlayouts speichert, können Sie die Masterfolie verwenden, um auf die Folienlayouts zuzugreifen und Änderungen daran vorzunehmen. Eine Layoutfolie kann nach Typ oder Name abgerufen werden. Ebenso hat jede Folie eine eindeutige ID, die verwendet werden kann, um auf sie zuzugreifen.

Alternativ können Sie Änderungen direkt an einem bestimmten Folienlayout in einer Präsentation vornehmen.

* Um Ihnen die Arbeit mit Folienlayouts (einschließlich der in Masterfolien) zu ermöglichen, bietet Aspose.Slides Eigenschaften wie [getLayoutSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getLayoutSlides--) und [getMasters()](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getMasters--) in der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse.
* Um verwandte Aufgaben durchzuführen, stellt Aspose.Slides [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/masterlayoutslidecollection/), [SlideSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/), [BaseSlideHeaderFooterManager](https://reference.aspose.com/slides/php-java/aspose.slides/baseslideheaderfootermanager/) und viele andere Typen zur Verfügung.

{{% alert title="Info" color="info" %}}

Für weitere Informationen zur Arbeit mit Masterfolien im Besonderen siehe den Artikel [Slide Master](https://docs.aspose.com/slides/php-java/slide-master/).

{{% /alert %}}

## **Folienlayout zur Präsentation hinzufügen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse.
1. Greifen Sie auf die [MasterSlide-Sammlung](https://reference.aspose.com/slides/php-java/aspose.slides/imasterlayoutslidecollection/) zu.
1. Durchsuchen Sie die vorhandenen Layoutfolien, um zu bestätigen, dass die erforderliche Layoutfolie bereits in der LayoutFolien-Sammlung vorhanden ist. Andernfalls fügen Sie die gewünschte Layoutfolie hinzu.
1. Fügen Sie eine leere Folie auf der Grundlage der neuen Layoutfolie hinzu.
1. Speichern Sie die Präsentation.

Dieser PHP-Code zeigt Ihnen, wie Sie ein Folienlayout zu einer PowerPoint-Präsentation hinzufügen:

```php
  # Instanziiert eine Präsentation-Klasse, die die Präsentationsdatei repräsentiert
  $pres = new Presentation("AccessSlides.pptx");
  try {
    # Durchläuft Layoutfolien-Typen
    $layoutSlides = $pres->getMasters()->get_Item(0)->getLayoutSlides();
    $layoutSlide = null;
    if (!java_is_null($layoutSlides->getByType(SlideLayoutType::TitleAndObject))) {
      $layoutSlide = $layoutSlides->getByType(SlideLayoutType::TitleAndObject);
    } else {
      $layoutSlide = $layoutSlides->getByType(SlideLayoutType::Title);
    }
    if (java_is_null($layoutSlide)) {
      # Die Situation, in der eine Präsentation einige Layouttypen nicht enthält.
      # Die Präsentationsdatei enthält nur leere und benutzerdefinierte Layouttypen.
      # Aber Layoutfolien mit benutzerdefinierten Typen haben unterschiedliche Foliennamen,
      # wie "Titel", "Titel und Inhalt" usw. Und es ist möglich, diese
      # Namen für die Auswahl der Layoutfolie zu verwenden.
      # Sie können auch eine Sammlung von Platzhalterformtypen verwenden. Zum Beispiel,
      # sollten Titel-Folien nur Typ Titel Platzhalter haben usw.
      foreach($layoutSlides as $titleAndObjectLayoutSlide) {
        if (java_values($titleAndObjectLayoutSlide->getName()) == "Title and Object") {
          $layoutSlide = $titleAndObjectLayoutSlide;
          break;
        }
      }
      if (java_is_null($layoutSlide)) {
        foreach($layoutSlides as $titleLayoutSlide) {
          if (java_values($titleLayoutSlide->getName()) == "Title") {
            $layoutSlide = $titleLayoutSlide;
            break;
          }
        }
        if (java_is_null($layoutSlide)) {
          $layoutSlide = $layoutSlides->getByType(SlideLayoutType::Blank);
          if (java_is_null($layoutSlide)) {
            $layoutSlide = $layoutSlides->add(SlideLayoutType::TitleAndObject, "Title and Object");
          }
        }
      }
    }
    # Fügt leere Folie mit hinzugefügter Layoutfolie hinzu
    $pres->getSlides()->insertEmptySlide(0, $layoutSlide);
    # Speichert die Präsentation auf der Festplatte
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Nicht verwendete Layoutfolie entfernen**

Aspose.Slides bietet die [removeUnusedLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) Methode der [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/) Klasse, um unerwünschte und nicht verwendete Layoutfolien zu löschen. Dieser PHP-Code zeigt Ihnen, wie Sie eine Layoutfolie aus einer PowerPoint-Präsentation entfernen:

```php
  $pres = new Presentation("pres.pptx");
  try {
    Compress->removeUnusedLayoutSlides($pres);
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Größe und Typ für Folienlayout festlegen**

Um Ihnen zu ermöglichen, Größe und Typ für eine bestimmte Layoutfolie festzulegen, bietet Aspose.Slides die Eigenschaften [getType()](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/#getType--) und [getSize()](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/#getSize--) (aus der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse). Dieser Java demonstriert die Operation:

```php
  # Instanziiert ein Präsentationsobjekt, das die Präsentationsdatei repräsentiert
  $presentation = new Presentation("demo.pptx");
  try {
    $auxPresentation = new Presentation();
    try {
      # Setzt die Foliengröße für die generierte Präsentation auf die des Quell
      $auxPresentation->getSlideSize()->setSize(540, 720, SlideSizeScaleType::EnsureFit);
      # getType());
      $auxPresentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::Maximize);
      # Klont die erforderliche Folie
      $auxPresentation->getSlides()->addClone($presentation->getSlides()->get_Item(0));
      $auxPresentation->getSlides()->removeAt(0);
      # Speichert die Präsentation auf der Festplatte
      $auxPresentation->save("size.pptx", SaveFormat::Pptx);
    } finally {
      $auxPresentation->dispose();
    }
  } finally {
    $presentation->dispose();
  }
```

## **Sichtbarkeit der Fußzeile innerhalb der Folie festlegen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse.
1. Holen Sie sich einen Verweis auf eine Folie über ihren Index.
1. Setzen Sie den Platzhalter für die Folienfußzeile auf sichtbar. 
1. Setzen Sie den Platzhalter für Datum und Uhrzeit auf sichtbar.
1. Speichern Sie die Präsentation.

Dieser PHP-Code zeigt Ihnen, wie Sie die Sichtbarkeit für eine Folienfußzeile festlegen (und verwandte Aufgaben durchführen):

```php
  $presentation = new Presentation("presentation.ppt");
  try {
    $headerFooterManager = $presentation->getSlides()->get_Item(0)->getHeaderFooterManager();
    # Methode isFooterVisible wird verwendet, um anzugeben, dass ein Platzhalter für die Folienfußzeile fehlt
    if (!$headerFooterManager->isFooterVisible()) {
      $headerFooterManager->setFooterVisibility(true);// Methode setFooterVisibility wird verwendet, um einen Platzhalter für die Folienfußzeile sichtbar zu machen

    }
    # Methode isSlideNumberVisible wird verwendet, um anzugeben, dass ein Platzhalter für die Foliennummer fehlt
    if (!$headerFooterManager->isSlideNumberVisible()) {
      $headerFooterManager->setSlideNumberVisibility(true);// Methode setSlideNumberVisibility wird verwendet, um einen Platzhalter für die Foliennummer sichtbar zu machen

    }
    # Methode isDateTimeVisible wird verwendet, um anzugeben, dass ein Platzhalter für Datum und Uhrzeit fehlt
    if (!$headerFooterManager->isDateTimeVisible()) {
      $headerFooterManager->setDateTimeVisibility(true);// Methode SetFooterVisibility wird verwendet, um einen Platzhalter für Datum und Uhrzeit sichtbar zu machen

    }
    $headerFooterManager->setFooterText("Fußzeilentext");// Methode SetFooterText wird verwendet, um einen Text für einen Platzhalter der Folienfußzeile festzulegen.

    $headerFooterManager->setDateTimeText("Datum und Uhrzeit Text");// Methode SetDateTimeText wird verwendet, um einen Text für einen Platzhalter für Datum und Uhrzeit festzulegen.

  } finally {
    $presentation->dispose();
  }
```

## **Sichtbarkeit der Kindfußzeile innerhalb der Folie festlegen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse.
1. Holen Sie sich einen Verweis auf die Masterfolie über ihren Index. 
1. Setzen Sie die Masterfolie und alle Platzhalter der Kindfußzeilen auf sichtbar.
1. Setzen Sie einen Text für die Masterfolie und alle Platzhalter der Kindfußzeilen. 
1. Setzen Sie einen Text für die Masterfolie und alle Platzhalter für Datum und Uhrzeit. 
1. Speichern Sie die Präsentation.

Dieser PHP-Code demonstriert die Operation:

```php
  $presentation = new Presentation("presentation.ppt");
  try {
    $headerFooterManager = $presentation->getMasters()->get_Item(0)->getHeaderFooterManager();
    $headerFooterManager->setFooterAndChildFootersVisibility(true);// Methode setFooterAndChildFootersVisibility wird verwendet, um die Masterfolie und alle Platzhalter der Kindfußzeilen sichtbar zu machen

    $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);// Methode setSlideNumberAndChildSlideNumbersVisibility wird verwendet, um die Masterfolie und alle Platzhalter für die Seitenzahlen der Kinder sichtbar zu machen

    $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);// Methode setDateTimeAndChildDateTimesVisibility wird verwendet, um eine Masterfolie und alle Platzhalter für Datum und Uhrzeit sichtbar zu machen

    $headerFooterManager->setFooterAndChildFootersText("Fußzeilentext");// Methode setFooterAndChildFootersText wird verwendet, um Texte für die Masterfolie und alle Platzhalter der Kindfußzeilen festzulegen

    $headerFooterManager->setDateTimeAndChildDateTimesText("Datum und Uhrzeit Text");// Methode setDateTimeAndChildDateTimesText wird verwendet, um den Text für die Masterfolie und alle Platzhalter der Kinddatum- und Uhrzeit festzulegen

  } finally {
    $presentation->dispose();
  }
```

## **Foliengröße im Hinblick auf die Inhaltsskalierung festlegen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse und laden Sie die Präsentation, die die Folie enthält, deren Größe Sie festlegen möchten.
1. Erstellen Sie eine andere Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse, um eine neue Präsentation zu erstellen.
1. Holen Sie sich den Verweis auf die Folie (aus der ersten Präsentation) über ihren Index.
1. Setzen Sie den Platzhalter für die Fußzeile auf sichtbar. 
1. Setzen Sie den Platzhalter für Datum und Uhrzeit auf sichtbar. 
1. Speichern Sie die Präsentation.

Dieser PHP-Code demonstriert die Operation:

```php
  # Instanziiert ein Präsentationsobjekt, das eine Präsentationsdatei repräsentiert
  $presentation = new Presentation("demo.pptx");
  try {
    # Setzt die Foliengröße für die generierten Präsentationen auf die des Quell
    $presentation->getSlideSize()->setSize(540, 720, SlideSizeScaleType::EnsureFit);// Methode SetSize wird verwendet, um die Foliengröße mit skalierendem Inhalt festzulegen, um Anpassung sicherzustellen

    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::Maximize);// Methode SetSize wird verwendet, um die Foliengröße mit der maximalen Größe des Inhalts festzulegen

    # Speichert die Präsentation auf der Festplatte
    $presentation->save("Set_Size&Type_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Seitenformat beim Generieren von PDF festlegen**

Bestimmte Präsentationen (wie Poster) werden oft in PDF-Dokumente umgewandelt. Wenn Sie Ihre PowerPoint in PDF umwandeln möchten, um die besten Druck- und Zugänglichkeitsoptionen zu nutzen, möchten Sie Ihre Folien auf Größen einstellen, die für PDF-Dokumente geeignet sind (z. B. A4).

Aspose.Slides bietet die [SlideSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/) Klasse, um Ihnen die Angabe Ihrer bevorzugten Einstellungen für Folien zu ermöglichen. Dieser PHP-Code zeigt Ihnen, wie Sie die [getType()](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/#getType--) Eigenschaft (aus der `SlideSize` Klasse) verwenden, um eine spezifische Papiergröße für die Folien in einer Präsentation festzulegen:

```php
  # Instanziiert ein Präsentationsobjekt, das eine Präsentationsdatei repräsentiert
  $presentation = new Presentation();
  try {
    # Setzt die SlideSize.Type-Eigenschaft
    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::EnsureFit);
    # Setzt verschiedene Eigenschaften für PDF-Optionen
    $opts = new PdfOptions();
    $opts->setSufficientResolution(600);
    # Speichert die Präsentation auf der Festplatte
    $presentation->save("SetPDFPageSize_out.pdf", SaveFormat::Pdf, $opts);
  } finally {
    $presentation->dispose();
  }
```