---
title: Folien aus Präsentationen in PHP entfernen
linktitle: Folie entfernen
type: docs
weight: 30
url: /de/php-java/remove-slide-from-presentation/
keywords:
- Folie entfernen
- Folie löschen
- Unbenutzte Folie entfernen
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Entfernen Sie mühelos Folien aus PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für PHP via Java. Erhalten Sie klare Code-Beispiele und steigern Sie Ihren Arbeitsablauf."
---

Wenn eine Folie (oder ihr Inhalt) überflüssig wird, können Sie sie löschen. Aspose.Slides stellt die [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse bereit, die [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/islidecollection/) kapselt, die ein Repository für alle Folien in einer Präsentation ist. Durch die Verwendung von Zeigern (Referenz oder Index) für ein bekanntes [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide/) Objekt können Sie die Folie angeben, die Sie entfernen möchten.

## **Entfernen einer Folie per Referenz**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse.  
1. Holen Sie sich eine Referenz der Folie, die Sie entfernen möchten, über deren ID oder Index.  
1. Entfernen Sie die referenzierte Folie aus der Präsentation.  
1. Speichern Sie die geänderte Präsentation.  

Dieser PHP‑Code zeigt, wie Sie eine Folie über ihre Referenz entfernen:
```php
  # Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
  $pres = new Presentation("demo.pptx");
  try {
    # Greift auf eine Folie über ihren Index in der Folienkollektion zu
    $slide = $pres->getSlides()->get_Item(0);
    # Entfernt eine Folie über ihre Referenz
    $pres->getSlides()->remove($slide);
    # Speichert die geänderte Präsentation
    $pres->save("modified.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **Entfernen einer Folie per Index**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse.  
1. Entfernen Sie die Folie aus der Präsentation über ihre Indexposition.  
1. Speichern Sie die geänderte Präsentation.  

Dieser PHP‑Code zeigt, wie Sie eine Folie über ihren Index entfernen:
```php
  # Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
  $pres = new Presentation("demo.pptx");
  try {
    # Entfernt eine Folie über ihren Folienindex
    $pres->getSlides()->removeAt(0);
    # Speichert die geänderte Präsentation
    $pres->save("modified.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **Unbenutzte Layout‑Folien entfernen**

Aspose.Slides stellt die [removeUnusedLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) Methode (aus der [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/) Klasse) bereit, mit der Sie unerwünschte und unbenutzte Layout‑Folien löschen können. Dieser PHP‑Code zeigt, wie Sie eine Layout‑Folie aus einer PowerPoint‑Präsentation entfernen:
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


## **Unbenutzte Master‑Folien entfernen**

Aspose.Slides stellt die [removeUnusedMasterSlides](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) Methode (aus der [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/) Klasse) bereit, mit der Sie unerwünschte und unbenutzte Master‑Folien löschen können. Dieser PHP‑Code zeigt, wie Sie eine Master‑Folie aus einer PowerPoint‑Präsentation entfernen:
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


## **FAQ**

**Was passiert mit Folienindizes, nachdem ich eine Folie gelöscht habe?**

Nach dem Löschen wird die [collection](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) neu indiziert: Jede nachfolgende Folie rückt um eine Position nach links, sodass frühere Indexzahlen veraltet sind. Wenn Sie eine stabile Referenz benötigen, verwenden Sie die dauerhafte ID jeder Folie statt ihres Index.

**Unterscheidet sich die ID einer Folie von ihrem Index, und ändert sie sich, wenn benachbarte Folien gelöscht werden?**

Ja. Der Index ist die Position der Folie und ändert sich, wenn Folien hinzugefügt oder entfernt werden. Die Folien‑ID ist ein dauerhafter Bezeichner und ändert sich nicht, wenn andere Folien gelöscht werden.

**Wie wirkt sich das Löschen einer Folie auf Folienabschnitte aus?**

Wenn die Folie zu einem Abschnitt gehörte, enthält dieser Abschnitt einfach eine Folie weniger. Die Abschnittsstruktur bleibt erhalten; wird ein Abschnitt leer, können Sie [Abschnitte entfernen oder neu organisieren](/slides/de/php-java/slide-section/) nach Bedarf.

**Was passiert mit Notizen und Kommentaren, die an einer Folie angehängt sind, wenn sie gelöscht wird?**

[Notes](/slides/de/php-java/presentation-notes/) und [comments](/slides/de/php-java/presentation-comments/) sind an diese spezielle Folie gebunden und werden zusammen mit ihr entfernt. Inhalte anderer Folien bleiben unverändert.

**Wie unterscheidet sich das Löschen von Folien vom Aufräumen unbenutzter Layouts/Master?**

Das Löschen entfernt bestimmte normale Folien aus dem Deck. Das Aufräumen unbenutzter Layouts/Master entfernt Layout‑ oder Master‑Folien, auf die nichts verweist, reduziert die Dateigröße, ohne den Inhalt der verbleibenden Folien zu verändern. Diese Aktionen ergänzen sich: In der Regel zuerst löschen, dann aufräumen.