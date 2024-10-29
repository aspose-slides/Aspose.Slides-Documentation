---
title: Präsentation zusammenführen
type: docs
weight: 40
url: /de/php-java/merge-presentation/
keywords: "PowerPoint zusammenführen, PPTX, PPT, PowerPoint kombinieren, Präsentation zusammenführen, Präsentation kombinieren, Java"
description: "Präsentation oder Präsentationen zusammenführen"
---


{{% alert title="Tipp" color="primary" %}} 

Sie sollten die **Aspose kostenlose Online** [Merger-App](https://products.aspose.app/slides/merger) ausprobieren. Damit können Benutzer PowerPoint-Präsentationen im selben Format (PPT zu PPT, PPTX zu PPTX usw.) und Präsentationen in verschiedenen Formaten (PPT zu PPTX, PPTX zu ODP usw.) zusammenführen.

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **Präsentation Zusammenführen**

Wenn Sie eine Präsentation mit einer anderen zusammenführen, kombinieren Sie effektiv deren Folien in einer einzigen Präsentation, um eine Datei zu erhalten. 

{{% alert title="Info" color="info" %}}

Die meisten Präsentationsprogramme (PowerPoint oder OpenOffice) verfügen nicht über Funktionen, die es Benutzern ermöglichen, Präsentationen auf diese Weise zu kombinieren. 

[**Aspose.Slides für PHP über Java**](https://products.aspose.com/slides/php-java/) ermöglicht es Ihnen jedoch, Präsentationen auf verschiedene Weise zusammenzuführen. Sie können Präsentationen mit all ihren Formen, Stilen, Texten, Formatierungen, Kommentaren, Animationen usw. zusammenführen, ohne sich um den Verlust von Qualität oder Daten sorgen zu müssen.

**Siehe auch**

[Folien klonen](https://docs.aspose.com/slides/php-java/clone-slides/).

{{% /alert %}}

### **Was kann zusammengeführt werden**

Mit Aspose.Slides können Sie 

* gesamte Präsentationen. Alle Folien aus den Präsentationen landen in einer Präsentation
* bestimmte Folien. Ausgewählte Folien landen in einer Präsentation
* Präsentationen im selben Format (PPT zu PPT, PPTX zu PPTX usw.) und in verschiedenen Formaten (PPT zu PPTX, PPTX zu ODP usw.) zueinander. 

{{% alert title="Hinweis" color="warning" %}} 

Neben Präsentationen ermöglicht es Aspose.Slides, auch andere Dateien zusammenzuführen:

* [Bilder](https://products.aspose.com/slides/php-java/merger/image-to-image/), wie [JPG zu JPG](https://products.aspose.com/slides/php-java/merger/jpg-to-jpg/) oder [PNG zu PNG](https://products.aspose.com/slides/php-java/merger/png-to-png/)
* Dokumente, wie [PDF zu PDF](https://products.aspose.com/slides/php-java/merger/pdf-to-pdf/) oder [HTML zu HTML](https://products.aspose.com/slides/php-java/merger/html-to-html/)
* Und zwei verschiedene Dateien wie [Bild zu PDF](https://products.aspose.com/slides/php-java/merger/image-to-pdf/) oder [JPG zu PDF](https://products.aspose.com/slides/php-java/merger/jpg-to-pdf/) oder [TIFF zu PDF](https://products.aspose.com/slides/php-java/merger/tiff-to-pdf/).

{{% /alert %}}

### **Zusammenführungsoptionen**

Sie können Optionen anwenden, die bestimmen, ob

* jede Folie in der Ausgabpräsentation einen einzigartigen Stil beibehält
* ein bestimmter Stil für alle Folien in der Ausgabpräsentation verwendet wird. 

Um Präsentationen zusammenzuführen, bietet Aspose.Slides [AddClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) Methoden (aus dem [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection) Interface). Es gibt mehrere Implementierungen der `AddClone` Methoden, die die Parameter des Präsentation zusammenführungsprozesses definieren. Jedes Präsentationsobjekt hat eine [Slides](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) Sammlung, sodass Sie eine `AddClone` Methode von der Präsentation aufrufen können, in die Sie Folien zusammenführen möchten.

Die `AddClone` Methode gibt ein `ISlide` Objekt zurück, das ein Klon der Quellfolie ist. Die Folien in einer Ausgabpräsentation sind einfach eine Kopie der Folien aus der Quelle. Daher können Sie die resultierenden Folien ändern (zum Beispiel Stile oder Formatierungsoptionen oder Layouts anwenden), ohne sich Sorgen machen zu müssen, dass die Quellpräsentationen beeinträchtigt werden. 

## **Präsentationen zusammenführen** 

Aspose.Slides bietet die [**AddClone(ISlide)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) Methode, die es Ihnen ermöglicht, Folien zu kombinieren, während diese ihre Layouts und Stile beibehalten (Standardparameter).

Dieser PHP-Code zeigt Ihnen, wie Sie Präsentationen zusammenführen:

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

## **Präsentationen mit Masterfolie zusammenführen**

Aspose.Slides bietet die [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) Methode, die es Ihnen ermöglicht, Folien zusammenzuführen, während eine Masterfolien-Präsentationsvorlage angewendet wird. Auf diese Weise können Sie, falls nötig, den Stil der Folien in der Ausgabpräsentation ändern.

Dieser Code demonstriert die beschriebene Operation:

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

Das Folienlayout für die Masterfolie wird automatisch bestimmt. Wenn ein geeignetes Layout nicht bestimmt werden kann, wird, falls der Boolean-Parameter `allowCloneMissingLayout` der `AddClone` Methode auf true gesetzt ist, das Layout für die Quellfolie verwendet. Andernfalls wird eine [PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/PptxEditException) ausgelöst.

{{% /alert %}}

Wenn Sie möchten, dass die Folien in der Ausgabpräsentation ein anderes Folienlayout haben, verwenden Sie stattdessen die [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) Methode beim Zusammenführen.

## **Bestimmte Folien aus Präsentationen zusammenführen**

Dieser PHP-Code zeigt Ihnen, wie Sie bestimmte Folien aus verschiedenen Präsentationen auswählen und kombinieren können, um eine Ausgabepräsentation zu erhalten:

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

## **Präsentationen mit Folienlayout zusammenführen**

Dieser PHP-Code zeigt Ihnen, wie Sie Folien aus Präsentationen kombinieren können, während Sie Ihr bevorzugtes Folienlayout auf sie anwenden, um eine Ausgabepräsentation zu erhalten:

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

Um 2 Präsentationen mit unterschiedlichen Foliengrößen zusammenzuführen, müssen Sie eine der Präsentationen so anpassen, dass ihre Größe der einer anderen Präsentation entspricht. 

Dieser Beispielcode demonstriert die beschriebene Operation:

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

## **Folien in einen Präsentationsabschnitt zusammenführen**

Dieser PHP-Code zeigt Ihnen, wie Sie eine bestimmte Folie in einen Abschnitt in einer Präsentation zusammenführen:

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

{{% alert title="Tipp" color="primary" %}}

Aspose bietet eine [KOSTENLOSE Collage-Webanwendung](https://products.aspose.app/slides/collage). Mit diesem Online-Service können Sie [JPG zu JPG](https://products.aspose.app/slides/collage/jpg) oder PNG zu PNG Bilder zusammenführen, [Fotogitter](https://products.aspose.app/slides/collage/photo-grid) erstellen und vieles mehr. 

{{% /alert %}}