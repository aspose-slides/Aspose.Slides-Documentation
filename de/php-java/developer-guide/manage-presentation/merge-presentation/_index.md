---
title: Präsentationen in PHP effizient zusammenführen
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
description: "PowerPoint (PPT, PPTX) und OpenDocument (ODP) Präsentationen mühelos mit Aspose.Slides für PHP via Java zusammenführen und den Arbeitsablauf optimieren."
---

## **Präsentationszusammenführung**

Wenn Sie eine Präsentation mit einer anderen zusammenführen, kombinieren Sie im Wesentlichen deren Folien in einer einzigen Präsentation, um eine Datei zu erhalten. 

{{% alert title="Info" color="info" %}}
Die meisten Präsentationsprogramme (PowerPoint oder OpenOffice) verfügen nicht über Funktionen, die es Benutzern ermöglichen, Präsentationen auf diese Weise zu kombinieren. 

[**Aspose.Slides für PHP via Java**](https://products.aspose.com/slides/php-java/), ermöglicht jedoch das Zusammenführen von Präsentationen auf verschiedene Arten. Sie können Präsentationen mit allen ihren Formen, Stilen, Texten, Formatierungen, Kommentaren, Animationen usw. zusammenführen, ohne sich um Qualitäts- oder Datenverlust sorgen zu müssen.

**Siehe auch**

[Folien duplizieren](https://docs.aspose.com/slides/php-java/clone-slides/).

{{% /alert %}}

### **Was kann zusammengeführt werden**

Mit Aspose.Slides können Sie 

* komplette Präsentationen. Alle Folien aus den Präsentationen landen in einer einzigen Präsentation
* bestimmte Folien. Ausgewählte Folien landen in einer einzigen Präsentation
* Präsentationen im selben Format (PPT zu PPT, PPTX zu PPTX usw.) und in unterschiedlichen Formaten (PPT zu PPTX, PPTX zu ODP usw.) miteinander. 

{{% alert title="Note" color="warning" %}} 

Zusätzlich zu Präsentationen ermöglicht Aspose.Slides das Zusammenführen anderer Dateien:

* [Bilder](https://products.aspose.com/slides/php-java/merger/image-to-image/), wie z.B. [JPG zu JPG](https://products.aspose.com/slides/php-java/merger/jpg-to-jpg/) oder [PNG zu PNG](https://products.aspose.com/slides/php-java/merger/png-to-png/)
* Dokumente, wie z.B. [PDF zu PDF](https://products.aspose.com/slides/php-java/merger/pdf-to-pdf/) oder [HTML zu HTML](https://products.aspose.com/slides/php-java/merger/html-to-html/)
* Und zwei unterschiedliche Dateien, wie z.B. [Bild zu PDF](https://products.aspose.com/slides/php-java/merger/image-to-pdf/) oder [JPG zu PDF](https://products.aspose.com/slides/php-java/merger/jpg-to-pdf/) oder [TIFF zu PDF](https://products.aspose.com/slides/php-java/merger/tiff-to-pdf/).

{{% /alert %}}

### **Zusammenführungsoptionen**

Sie können Optionen anwenden, die bestimmen, ob

* jede Folie in der Ausgabepäsentation einen eindeutigen Stil behält
* ein bestimmter Stil für alle Folien in der Ausgabepäsentation verwendet wird. 

Um Präsentationen zusammenzuführen, stellt Aspose.Slides die [AddClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) Methoden (aus dem [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection) Interface) bereit. Es gibt mehrere Implementierungen der `AddClone`‑Methoden, die die Parameter des Präsentationszusammenführungsprozesses definieren. Jedes Presentation‑Objekt verfügt über eine [Slides](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) Sammlung, sodass Sie eine `AddClone`‑Methode von der Präsentation aus aufrufen können, zu der Sie Folien zusammenführen möchten.

Die `AddClone`‑Methode gibt ein `ISlide`‑Objekt zurück, das ein Klon der Quellfolie ist. Die Folien in einer Ausgabepäsentation sind einfach Kopien der Folien aus der Quelle. Daher können Sie Änderungen an den resultierenden Folien vornehmen (z.B. Stile oder Formatierungsoptionen oder Layouts anwenden), ohne dass die Quellpräsentationen betroffen sind. 

## **Präsentationen zusammenführen** 

Aspose.Slides stellt die [**AddClone(ISlide)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) Methode bereit, die es ermöglicht, Folien zu kombinieren, wobei die Folien ihre Layouts und Stile beibehalten (Standardparameter).

Dieser PHP‑Code zeigt, wie Präsentationen zusammengeführt werden:
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

Aspose.Slides stellt die [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) Methode bereit, die es ermöglicht, Folien zu kombinieren, während eine Folienmaster‑Präsentationsvorlage angewendet wird. Auf diese Weise können Sie bei Bedarf den Stil für die Folien in der Ausgabepäsentation ändern.

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


{{% alert title="Note" color="warning" %}} 

Das Folienlayout für den Folienmaster wird automatisch ermittelt. Wenn kein geeignetes Layout ermittelt werden kann und der boolesche Parameter `allowCloneMissingLayout` der `AddClone`‑Methode auf true gesetzt ist, wird das Layout der Quellfolie verwendet. Andernfalls wird eine [PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/PptxEditException) ausgelöst.

{{% /alert %}}

Wenn Sie möchten, dass die Folien in der Ausgabepäsentation ein anderes Folienlayout haben, verwenden Sie stattdessen die [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) Methode beim Zusammenführen.

## **Bestimmte Folien aus Präsentationen zusammenführen** 

Das Zusammenführen bestimmter Folien aus mehreren Präsentationen ist nützlich, um benutzerdefinierte Folien-Sets zu erstellen. Aspose.Slides für PHP via Java ermöglicht es, nur die benötigten Folien auszuwählen und zu importieren. Die API bewahrt Formatierung, Layout und Design der Originalfolien.

Der folgende PHP‑Code erstellt eine neue Präsentation, fügt Titelfolien aus zwei anderen Präsentationen hinzu und speichert das Ergebnis in einer Datei:
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

Dieser PHP‑Code zeigt, wie Folien aus Präsentationen kombiniert werden, wobei das bevorzugte Folienlayout angewendet wird, um eine einzige Ausgabepäsentation zu erhalten:
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

{{% alert title="Note" color="warning" %}} 

Sie können Präsentationen mit unterschiedlichen Foliengrößen nicht zusammenführen. 

{{% /alert %}}

Um zwei Präsentationen mit unterschiedlichen Foliengrößen zusammenzuführen, müssen Sie eine der Präsentationen so skalieren, dass ihre Größe der der anderen Präsentation entspricht. 

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

Dieser PHP‑Code zeigt, wie eine bestimmte Folie zu einem Abschnitt in einer Präsentation zusammengeführt wird:
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


Die Folie wird am Ende des Abschnitts hinzugefügt. 

## **Siehe auch**


Aspose stellt einen [KOSTENLOSEN Online‑Collage‑Ersteller](https://products.aspose.app/slides/collage) bereit. Mit diesem Online‑Dienst können Sie [JPG zu JPG](https://products.aspose.app/slides/collage/jpg) oder PNG zu PNG Bilder zusammenführen, [Fotogitter](https://products.aspose.app/slides/collage/photo-grid) erstellen und mehr.

Probieren Sie den [Aspose KOSTENLOSEN Online‑Merger](https://products.aspose.app/slides/merger) aus. Er ermöglicht das Zusammenführen von PowerPoint‑Präsentationen im gleichen Format (z.B. PPT zu PPT, PPTX zu PPTX) oder über verschiedene Formate hinweg (z.B. PPT zu PPTX, PPTX zu ODP).

[![Aspose KOSTENLOSER Online-Merger](slides-merger.png)](https://products.aspose.app/slides/merger)

## **FAQ**

**Gibt es Beschränkungen bezüglich der Folienzahl beim Zusammenführen von Präsentationen?**

Keine strengen Beschränkungen. Aspose.Slides kann große Dateien verarbeiten, jedoch hängt die Leistung von der Größe und den Systemressourcen ab. Für sehr große Präsentationen wird empfohlen, eine 64‑Bit‑JVM zu verwenden und ausreichend Heap‑Speicher zuzuweisen.

**Kann ich Präsentationen mit eingebettetem Video oder Audio zusammenführen?**

Ja, Aspose.Slides bewahrt multimediale Inhalte, die in Folien eingebettet sind, jedoch kann die endgültige Präsentation deutlich größer werden.

**Werden Schriftarten beim Zusammenführen von Präsentationen erhalten bleiben?**

Ja. Schriftarten, die in den Quellpräsentationen verwendet werden, bleiben in der Ausgabedatei erhalten, vorausgesetzt, sie sind auf dem System installiert oder [eingebettet](/slides/de/php-java/embedded-font/).