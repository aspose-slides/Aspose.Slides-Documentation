---
title: Folie aus Präsentation entfernen
type: docs
weight: 30
url: /de/php-java/remove-slide-from-presentation/
keywords: "Folie entfernen, Folie löschen, PowerPoint, Präsentation, Java, Aspose.Slides"
description: "Entfernen Sie Folien aus PowerPoint nach Referenz oder Index"

---

Wenn eine Folie (oder deren Inhalt) überflüssig wird, können Sie sie löschen. Aspose.Slides bietet die [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse, die [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/islidecollection/) kapselt, welche ein Repository für alle Folien in einer Präsentation ist. Mithilfe von Zeigern (Referenz oder Index) für ein bekanntes [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide/) Objekt können Sie die Folie angeben, die Sie entfernen möchten.

## **Folie nach Referenz entfernen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse.
1. Holen Sie sich eine Referenz der Folie, die Sie entfernen möchten, über ihre ID oder ihren Index.
1. Entfernen Sie die referenzierte Folie aus der Präsentation.
1. Speichern Sie die modifizierte Präsentation.

Dieser PHP-Code zeigt Ihnen, wie Sie eine Folie über ihre Referenz entfernen:

```php
  # Instanziiert ein Präsentationsobjekt, das eine Präsentationsdatei darstellt
  $pres = new Presentation("demo.pptx");
  try {
    # Greift auf eine Folie über ihren Index in der Folien-Kollektion zu
    $slide = $pres->getSlides()->get_Item(0);
    # Entfernt eine Folie über ihre Referenz
    $pres->getSlides()->remove($slide);
    # Speichert die modifizierte Präsentation
    $pres->save("modified.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Folie nach Index entfernen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse.
1. Entfernen Sie die Folie aus der Präsentation über ihre Indexposition.
1. Speichern Sie die modifizierte Präsentation.

Dieser PHP-Code zeigt Ihnen, wie Sie eine Folie über ihren Index entfernen:

```php
  # Instanziiert ein Präsentationsobjekt, das eine Präsentationsdatei darstellt
  $pres = new Presentation("demo.pptx");
  try {
    # Entfernt eine Folie über ihren Folienindex
    $pres->getSlides()->removeAt(0);
    # Speichert die modifizierte Präsentation
    $pres->save("modified.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Ungenutzte Layoutfolie entfernen**

Aspose.Slides bietet die [removeUnusedLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) Methode (aus der [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/) Klasse), um nicht gewollte und ungenutzte Layoutfolien zu löschen. Dieser PHP-Code zeigt Ihnen, wie Sie eine Layoutfolie aus einer PowerPoint-Präsentation entfernen:

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

## **Ungenutzte Masterfolie entfernen**

Aspose.Slides bietet die [removeUnusedMasterSlides](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) Methode (aus der [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/) Klasse), um nicht gewollte und ungenutzte Masterfolien zu löschen. Dieser PHP-Code zeigt Ihnen, wie Sie eine Masterfolie aus einer PowerPoint-Präsentation entfernen:

```php
  $pres = new Presentation("pres.pptx");
  try {
    Compress->removeUnusedMasterSlides($pres);
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```