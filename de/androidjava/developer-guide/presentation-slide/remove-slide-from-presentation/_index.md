---
title: Folien aus Präsentationen auf Android entfernen
linktitle: Folie entfernen
type: docs
weight: 30
url: /de/androidjava/remove-slide-from-presentation/
keywords:
- Folien entfernen
- Folien löschen
- unbenutzte Folien entfernen
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Entfernen Sie mühelos Folien aus PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Android. Erhalten Sie übersichtliche Java-Code-Beispiele und steigern Sie Ihren Arbeitsablauf."
---

Wenn eine Folie (oder ihr Inhalt) redundant wird, können Sie sie löschen. Aspose.Slides stellt die [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)-Klasse bereit, die [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/) kapselt, welche ein Repository für alle Folien in einer Präsentation ist. Durch Verwendung von Zeigern (Referenz oder Index) für ein bekanntes [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/)-Objekt können Sie die Folie angeben, die Sie entfernen möchten.

## **Folie per Referenz entfernen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)-Klasse.
1. Holen Sie eine Referenz der Folie, die Sie entfernen möchten, über deren ID oder Index.
1. Entfernen Sie die referenzierte Folie aus der Präsentation.
1. Speichern Sie die geänderte Präsentation.

Dieser Java-Code zeigt, wie Sie eine Folie über ihre Referenz entfernen:
```java
// Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
Presentation pres = new Presentation("demo.pptx");
try {
    // Greift über den Index in der Folien-Sammlung auf eine Folie zu
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Entfernt eine Folie über ihre Referenz
    pres.getSlides().remove(slide);
    
    // Speichert die geänderte Präsentation
    pres.save("modified.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Folie per Index entfernen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)-Klasse.
1. Entfernen Sie die Folie aus der Präsentation über ihre Indexposition.
1. Speichern Sie die geänderte Präsentation.

Dieser Java-Code zeigt, wie Sie eine Folie über ihren Index entfernen:
```java
// Instanziert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
Presentation pres = new Presentation("demo.pptx");
try {
    // Entfernt eine Folie über ihren Index
    pres.getSlides().removeAt(0);
    
    // Speichert die geänderte Präsentation
    pres.save("modified.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Unbenutzte Layout‑Folien entfernen**

Aspose.Slides stellt die Methode [removeUnusedLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) (aus der Klasse [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/)) bereit, mit der Sie unerwünschte und unbenutzte Layout‑Folien löschen können. Dieser Java-Code zeigt, wie Sie eine Layout‑Folie aus einer PowerPoint‑Präsentation entfernen:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.removeUnusedLayoutSlides(pres);

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Unbenutzte Master‑Folien entfernen**

Aspose.Slides stellt die Methode [removeUnusedMasterSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (aus der Klasse [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/)) bereit, mit der Sie unerwünschte und unbenutzte Master‑Folien löschen können. Dieser Java-Code zeigt, wie Sie eine Master‑Folie aus einer PowerPoint‑Präsentation entfernen:
```java
Presentation pres = new Presentation("pres.pptx");
 try {
     Compress.removeUnusedMasterSlides(pres);

     pres.save("pres-out.pptx", SaveFormat.Pptx);
 } finally {
     if (pres != null) pres.dispose();
 }
```


## **FAQ**

**Was passiert mit Folien‑Indizes, nachdem ich eine Folie gelöscht habe?**

Nach dem Löschen reindiziert die [collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/) – jede nachfolgende Folie verschiebt sich um eine Position nach links, sodass frühere Indexzahlen veraltet sind. Wenn Sie einen stabilen Verweis benötigen, verwenden Sie die dauerhafte ID jeder Folie statt ihres Index.

**Unterscheidet sich die ID einer Folie vom Index und ändert sie sich, wenn benachbarte Folien gelöscht werden?**

Ja. Der Index ist die Position der Folie und ändert sich, wenn Folien hinzugefügt oder entfernt werden. Die Folien‑ID ist ein dauerhafter Bezeichner und ändert sich nicht, wenn andere Folien gelöscht werden.

**Wie wirkt sich das Löschen einer Folie auf Folienabschnitte aus?**

Wenn die Folie zu einem Abschnitt gehörte, enthält dieser Abschnitt einfach eine Folie weniger. Die Abschnittsstruktur bleibt erhalten; wird ein Abschnitt leer, können Sie [Abschnitte entfernen oder neu organisieren](/slides/de/androidjava/slide-section/) nach Bedarf.

**Was passiert mit Notizen und Kommentaren, die an einer Folie angehängt sind, wenn diese gelöscht wird?**

[Notes](/slides/de/androidjava/presentation-notes/) und [comments](/slides/de/androidjava/presentation-comments/) sind an dieser speziellen Folie gebunden und werden zusammen mit ihr entfernt. Der Inhalt anderer Folien bleibt unverändert.

**Wie unterscheidet sich das Löschen von Folien vom Aufräumen unbenutzter Layouts/Master?**

Das Löschen entfernt spezifische normale Folien aus der Präsentation. Das Aufräumen unbenutzter Layouts/Master entfernt Layout‑ oder Master‑Folien, auf die nichts verweist, reduziert die Dateigröße, ohne den verbleibenden Folieninhalt zu ändern. Diese Aktionen ergänzen sich: In der Regel zuerst löschen, dann aufräumen.