---
title: Effizientes Zusammenführen von Präsentationen in PHP
linktitle: Präsentationen zusammenführen
type: docs
weight: 40
url: /de/php-java/merge-presentation/
keywords:
- PowerPoint zusammenführen
- Präsentationen zusammenführen
- Folien zusammenführen
- PPT zusammenführen
- PPTX zusammenführen
- ODP zusammenführen
- PowerPoint kombinieren
- Präsentationen kombinieren
- Folien kombinieren
- PPT kombinieren
- PPTX kombinieren
- ODP kombinieren
- PHP
- Aspose.Slides
description: "Müheloses Zusammenführen von PowerPoint‑ (PPT, PPTX) und OpenDocument‑ (ODP) Präsentationen mit Aspose.Slides für PHP via Java, zur Optimierung Ihres Workflows."
---

## **Präsentationszusammenführung**

Wenn Sie eine Präsentation mit einer anderen zusammenführen, kombinieren Sie deren Folien effektiv in einer einzigen Präsentation, um eine Datei zu erhalten. 

{{% alert title="Info" color="info" %}}

Die meisten Präsentationsprogramme (PowerPoint oder OpenOffice) besitzen keine Funktionen, die es Benutzern ermöglichen, Präsentationen auf diese Weise zu kombinieren. 

[**Aspose.Slides for PHP via Java**](https://products.aspose.com/slides/php-java/), ermöglicht jedoch das Zusammenführen von Präsentationen auf verschiedene Arten. Sie können Präsentationen mit all ihren Formen, Stilen, Texten, Formatierungen, Kommentaren, Animationen usw. zusammenführen, ohne Qualitäts- oder Datenverlust befürchten zu müssen.

**Siehe auch**

[Folien klonen](/slides/de/php-java/clone-slides/).

{{% /alert %}}

### **Was kann zusammengeführt werden**

Mit Aspose.Slides können Sie

* komplette Präsentationen. Alle Folien aus den Präsentationen landen in einer einzigen Präsentation
* bestimmte Folien. Ausgewählte Folien landen in einer einzigen Präsentation
* Präsentationen im selben Format (PPT zu PPT, PPTX zu PPTX usw.) und in unterschiedlichen Formaten (PPT zu PPTX, PPTX zu ODP usw.) miteinander. 

{{% alert title="Hinweis" color="warning" %}} 

Neben Präsentationen ermöglicht Aspose.Slides das Zusammenführen anderer Dateien:

* [Bilder](https://products.aspose.com/slides/php-java/merger/image-to-image/), wie [JPG zu JPG](https://products.aspose.com/slides/php-java/merger/jpg-to-jpg/) oder [PNG zu PNG](https://products.aspose.com/slides/php-java/merger/png-to-png/)
* Dokumente, wie [PDF zu PDF](https://products.aspose.com/slides/php-java/merger/pdf-to-pdf/) oder [HTML zu HTML](https://products.aspose.com/slides/php-java/merger/html-to-html/)
* Und zwei unterschiedliche Dateien, wie [Bild zu PDF](https://products.aspose.com/slides/php-java/merger/image-to-pdf/), [JPG zu PDF](https://products.aspose.com/slides/php-java/merger/jpg-to-pdf/) oder [TIFF zu PDF](https://products.aspose.com/slides/php-java/merger/tiff-to-pdf/).

{{% /alert %}}

### **Zusammenführungsoptionen**

Sie können Optionen festlegen, die bestimmen, ob

* jede Folie in der Ausgabepäsentation einen eindeutigen Stil beibehält
* ein bestimmter Stil für alle Folien in der Ausgabepäsentation verwendet wird. 

Um Präsentationen zusammenzuführen, stellt Aspose.Slides die [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/addclone/)‑Methoden (aus der [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/)‑Klasse) bereit. Es gibt mehrere Implementierungen der `addClone`‑Methoden, die die Parameter des Zusammenführungsprozesses definieren. Jede Presentation‑Objekt hat eine [slide](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getslides/)‑Sammlung, sodass Sie die `addClone`‑Methode von der Präsentation aus aufrufen können, zu der Sie Folien hinzufügen möchten.

Die `addClone`‑Methode gibt ein `Slide`‑Objekt zurück, das ein Klon der Quellfolie ist. Die Folien in einer Ausgabepäsentation sind einfach Kopien der Folien aus der Quelle. Daher können Sie Änderungen an den resultierenden Folien vornehmen (z. B. Stile oder Formatierungsoptionen oder Layouts anwenden), ohne dass die Quellpräsentationen beeinflusst werden. 

## **Präsentationen zusammenführen** 

Aspose.Slides stellt die [addClone(Slide)](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/addclone/)‑Methode bereit, die das Kombinieren von Folien ermöglicht, während die Folien ihre Layouts und Stile beibehalten (Standardparameter).

Dieser PHP-Code zeigt, wie Sie Präsentationen zusammenführen:
```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```


## **Präsentationen mit einem Folienmaster zusammenführen**

Aspose.Slides stellt die [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/addclone/)‑Methode bereit, die das Kombinieren von Folien ermöglicht, wobei eine Folienmaster‑Vorlage angewendet wird. Auf diese Weise können Sie bei Bedarf den Stil für die Folien in der Ausgabepäsentation ändern.

Dieser Code demonstriert den beschriebenen Vorgang:
```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres2->getMasters()->get_Item(0), true);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```


{{% alert title="Hinweis" color="warning" %}} 

Das Folienlayout für den Folienmaster wird automatisch bestimmt. Wenn kein passendes Layout ermittelt werden kann und der boolesche Parameter `allowCloneMissingLayout` der `addClone`‑Methode auf true gesetzt ist, wird das Layout der Quellfolie verwendet. Andernfalls wird eine [PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/PptxEditException) ausgelöst.

{{% /alert %}}

Wenn die Folien in der Ausgabepäsentation ein anderes Folienlayout erhalten sollen, verwenden Sie stattdessen die [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/addclone/)‑Methode beim Zusammenführen.

## **Bestimmte Folien aus Präsentationen zusammenführen**

Das Zusammenführen bestimmter Folien aus mehreren Präsentationen ist nützlich, um benutzerdefinierte Folienpakete zu erstellen. Aspose.Slides for PHP via Java ermöglicht das Auswählen und Importieren nur der benötigten Folien. Die API bewahrt Formatierungen, Layout und Design der Originalfolien.

Der folgende PHP-Code erstellt eine neue Präsentation, fügt Titelfolien aus zwei anderen Präsentationen hinzu und speichert das Ergebnis in einer Datei:
```php
function getTitleSlide(Presentation $presentation) {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        if (java_values($slide->getLayoutSlide()->getLayoutType()) === SlideLayoutType::Title) {
            return $slide;
        }
    }
    return null;
}
```

```php
$presentation = new Presentation();
$presentation1 = new Presentation($folderPath . "presentation1.pptx");
$presentation2 = new Presentation($folderPath . "presentation2.pptx");
try {
    $presentation->getSlides()->removeAt(0);
    
    $slide1 = getTitleSlide($presentation1);

    if ($slide1 != null)
        $presentation->getSlides()->addClone($slide1);

    $slide2 = getTitleSlide($presentation2);

    if ($slide2 != null)
        $presentation->getSlides()->addClone($slide2);

    $presentation->save($folderPath . "combined.pptx", SaveFormat::Pptx);
} finally {
    $presentation2->dispose();
    $presentation1->dispose();
    $presentation->dispose();
}
```


## **Präsentationen mit einem Folienlayout zusammenführen**

Dieser PHP-Code zeigt, wie Sie Folien aus Präsentationen kombinieren und dabei Ihr bevorzugtes Folienlayout anwenden, um eine einzige Ausgabepäsentation zu erhalten:
```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres2->getLayoutSlides()->get_Item(0));
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```


## **Präsentationen mit unterschiedlichen Foliengrößen zusammenführen**

{{% alert title="Hinweis" color="warning" %}} 

Sie können keine Präsentationen mit unterschiedlichen Foliengrößen zusammenführen. 

{{% /alert %}}

Um 2 Präsentationen mit unterschiedlichen Foliengrößen zusammenzuführen, müssen Sie eine der Präsentationen in ihrer Größe an die der anderen anpassen. 

Dieser Beispielcode demonstriert den beschriebenen Vorgang:
```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      $pres2->getSlideSize()->setSize($pres1->getSlideSize()->getSize()->getWidth(), $pres1->getSlideSize()->getSize()->getHeight(), SlideSizeScaleType::EnsureFit);
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```


## **Folien zu einem Präsentationsabschnitt zusammenführen**

Dieser PHP-Code zeigt, wie Sie eine bestimmte Folie zu einem Abschnitt in einer Präsentation zusammenführen:
```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres1->getSections()->get_Item(0));
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```


Die Folie wird am Ende des Abschnitts eingefügt. 

## **Siehe auch**

Aspose bietet ein KOSTENLOSES Online‑Collage‑Tool an. Mit diesem Online‑Dienst können Sie [JPG zu JPG](https://products.aspose.app/slides/collage/jpg) oder PNG zu PNG‑Bilder zusammenführen, [Fotogitter](https://products.aspose.app/slides/collage/photo-grid) erstellen und mehr.

Probieren Sie den Aspose KOSTENLOSEN Online‑Merger. Er ermöglicht das Zusammenführen von PowerPoint‑Präsentationen im selben Format (z. B. PPT zu PPT, PPTX zu PPTX) oder über verschiedene Formate hinweg (z. B. PPT zu PPTX, PPTX zu ODP).

[![Aspose KOSTENLOSER Online-Merger](slides-merger.png)](https://products.aspose.app/slides/merger)

## **FAQ**

**Gibt es Beschränkungen für die Folienzahl beim Zusammenführen von Präsentationen?**

Keine strikten Beschränkungen. Aspose.Slides kann große Dateien verarbeiten, aber die Leistung hängt von der Dateigröße und den Systemressourcen ab. Für sehr große Präsentationen wird empfohlen, eine 64‑Bit‑JVM zu verwenden und ausreichend Heap‑Speicher zuzuweisen.

**Kann ich Präsentationen mit eingebetteten Video‑ oder Audiodateien zusammenführen?**

Ja, Aspose.Slides bewahrt eingebettete Multimedia‑Inhalte in Folien, allerdings kann die endgültige Präsentation deutlich größer werden.

**Werden Schriftarten beim Zusammenführen von Präsentationen beibehalten?**

Ja. Schriftarten, die in den Quellpräsentationen verwendet werden, bleiben in der Ausgabedatei erhalten, vorausgesetzt, sie sind im System installiert oder [eingebettet](/slides/de/php-java/embedded-font/).