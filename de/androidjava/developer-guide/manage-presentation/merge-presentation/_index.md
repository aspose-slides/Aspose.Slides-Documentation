---
title: Präsentationen auf Android effizient zusammenführen
linktitle: Präsentationen zusammenführen
type: docs
weight: 40
url: /de/androidjava/merge-presentation/
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
- Android
- Java
- Aspose.Slides
description: "PowerPoint (PPT, PPTX) und OpenDocument (ODP) Präsentationen mühelos mit Aspose.Slides für Android via Java zusammenführen und Ihren Arbeitsablauf optimieren."
---

{{% alert  title="Tip" color="primary" %}} 

Sie können die **Aspose kostenlose Online** [Merger-App](https://products.aspose.app/slides/merger) ausprobieren. Sie ermöglicht das Zusammenführen von PowerPoint‑Präsentationen im selben Format (PPT zu PPT, PPTX zu PPTX usw.) und das Zusammenführen von Präsentationen in unterschiedlichen Formaten (PPT zu PPTX, PPTX zu ODP usw.).

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **Präsentationszusammenführung**

Wenn Sie eine Präsentation mit einer anderen zusammenführen, kombinieren Sie im Wesentlichen deren Folien zu einer einzigen Präsentation, um eine Datei zu erhalten. 

{{% alert title="Info" color="info" %}}

Die meisten Präsentationsprogramme (PowerPoint oder OpenOffice) verfügen nicht über Funktionen, mit denen Benutzer Präsentationen auf diese Weise zusammenführen können. 

[**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/androidjava/), ermöglicht jedoch das Zusammenführen von Präsentationen auf verschiedene Arten. Sie können Präsentationen mit all ihren Formen, Stilen, Texten, Formatierungen, Kommentaren, Animationen usw. zusammenführen, ohne sich um Qualitäts- oder Datenverlust sorgen zu müssen.

**Siehe auch**

[Clone Slides](https://docs.aspose.com/slides/androidjava/clone-slides/).

{{% /alert %}}

### **Was kann zusammengeführt werden**

Mit Aspose.Slides können Sie zusammenführen 

* komplette Präsentationen. Alle Folien der Präsentationen werden in einer einzigen Präsentation zusammengeführt
* bestimmte Folien. Ausgewählte Folien werden in einer einzigen Präsentation zusammengeführt
* Präsentationen im selben Format (PPT zu PPT, PPTX zu PPTX usw.) sowie in unterschiedlichen Formaten (PPT zu PPTX, PPTX zu ODP usw.) miteinander. 

{{% alert title="Note" color="warning" %}} 

Zusätzlich zu Präsentationen ermöglicht Aspose.Slides das Zusammenführen anderer Dateien:

* [Bilder](https://products.aspose.com/slides/androidjava/merger/image-to-image/), zum Beispiel [JPG zu JPG](https://products.aspose.com/slides/androidjava/merger/jpg-to-jpg/) oder [PNG zu PNG](https://products.aspose.com/slides/androidjava/merger/png-to-png/)
* Dokumente, zum Beispiel [PDF zu PDF](https://products.aspose.com/slides/androidjava/merger/pdf-to-pdf/) oder [HTML zu HTML](https://products.aspose.com/slides/androidjava/merger/html-to-html/)
* Und zwei unterschiedliche Dateien, z. B. [Bild zu PDF](https://products.aspose.com/slides/androidjava/merger/image-to-pdf/), [JPG zu PDF](https://products.aspose.com/slides/androidjava/merger/jpg-to-pdf/) oder [TIFF zu PDF](https://products.aspose.com/slides/androidjava/merger/tiff-to-pdf/).

{{% /alert %}}

### **Zusammenführungsoptionen**

Sie können Optionen festlegen, die bestimmen, ob

* jede Folie in der Ausgabepäsentation einen individuellen Stil beibehält
* ein bestimmter Stil für alle Folien der Ausgabepresentation verwendet wird. 

Um Präsentationen zusammenzuführen, stellt Aspose.Slides die [AddClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)‑Methoden (von der [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection)‑Schnittstelle) bereit. Es gibt mehrere Implementierungen der `AddClone`‑Methoden, die die Parameter des Zusammenführungsprozesses definieren. Jedes Presentation‑Objekt besitzt eine [Slides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--)‑Sammlung, sodass Sie die `AddClone`‑Methode von der Präsentation aus aufrufen können, in die Sie Folien einfügen möchten.

Die `AddClone`‑Methode gibt ein `ISlide`‑Objekt zurück, das eine Kopie der Quellfolie ist. Die Folien in der Ausgabepäsentation sind einfach Kopien der Quellfolien. Daher können Sie die resultierenden Folien ändern (z. B. Stile, Formatierungsoptionen oder Layouts anwenden), ohne dass die Quellpräsentationen beeinflusst werden. 

## **Präsentationen zusammenführen** 

Aspose.Slides stellt die [**AddClone(ISlide)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)‑Methode bereit, mit der Sie Folien kombinieren können, wobei die Folien ihre Layouts und Stile beibehalten (Standardparameter).

Dieser Java‑Code zeigt, wie Sie Präsentationen zusammenführen können:
```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```


## **Präsentationen mit einem Folienmaster zusammenführen**

Aspose.Slides stellt die [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-)‑Methode bereit, mit der Sie Folien kombinieren können, während ein Folienmaster‑Präsentationsvorlage angewendet wird. Auf diese Weise können Sie bei Bedarf den Stil der Folien in der Ausgabepäsentation ändern.

Dieser Java‑Code demonstriert den beschriebenen Vorgang:
```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres2.getMasters().get_Item(0), true);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```


{{% alert title="Note" color="warning" %}} 

Das Folienlayout für den Folienmaster wird automatisch ermittelt. Wenn kein passendes Layout ermittelt werden kann und der boolesche Parameter `allowCloneMissingLayout` der `AddClone`‑Methode auf **true** gesetzt ist, wird das Layout der Quellfolie verwendet. Andernfalls wird eine [PptxEditException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PptxEditException) ausgelöst.

{{% /alert %}}

Wenn Sie möchten, dass die Folien in der Ausgabepäsentation ein anderes Folienlayout erhalten, verwenden Sie stattdessen die [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-)‑Methode beim Zusammenführen.

## **Bestimmte Folien aus Präsentationen zusammenführen**

Das Zusammenführen bestimmter Folien aus mehreren Präsentationen ist nützlich, um benutzerdefinierte Foliensets zu erstellen. Aspose.Slides for Android via Java ermöglicht das Auswählen und Importieren nur der benötigten Folien. Die API bewahrt Formatierung, Layout und Design der Originalfolien.

Der folgende Java‑Code erstellt eine neue Präsentation, fügt Titelfolien aus zwei anderen Präsentationen hinzu und speichert das Ergebnis in einer Datei:
```java
Presentation presentation = new Presentation();
Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    presentation.getSlides().removeAt(0);
    
    ISlide slide1 = getTitleSlide(presentation1);

    if (slide1 != null)
        presentation.getSlides().addClone(slide1);

    ISlide slide2 = getTitleSlide(presentation2);

    if (slide2 != null)
        presentation.getSlides().addClone(slide2);

    presentation.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
    presentation.dispose();
}
```

```java
static ISlide getTitleSlide(IPresentation presentation) {
    for (ISlide slide : presentation.getSlides()) {
        if (slide.getLayoutSlide().getLayoutType() == SlideLayoutType.Title) {
            return slide;
        }
    }
    return null;
}
```


## **Präsentationen mit einem Folienlayout zusammenführen**

Dieser Java‑Code zeigt, wie Sie Folien aus Präsentationen kombinieren und dabei Ihr bevorzugtes Folienlayout anwenden, um eine einzige Ausgabepäsentation zu erhalten:
```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres2.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```


## **Präsentationen mit unterschiedlichen Foliengrößen zusammenführen**

{{% alert title="Note" color="warning" %}} 

Sie können Präsentationen mit unterschiedlichen Foliengrößen nicht zusammenführen. 

{{% /alert %}}

Um 2 Präsentationen mit unterschiedlichen Foliengrößen zusammenzuführen, müssen Sie eine der Präsentationen skalieren, sodass ihre Größe der der anderen Präsentation entspricht. 

Dieser Beispielcode demonstriert den beschriebenen Vorgang:
```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        pres2.getSlideSize().setSize((float)pres1.getSlideSize().getSize().getWidth(), (float)pres1.getSlideSize().getSize().getHeight(), SlideSizeScaleType.EnsureFit);

        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```


## **Folien zu einem Präsentationsabschnitt zusammenführen**

Dieser Java‑Code zeigt, wie Sie eine bestimmte Folie zu einem Abschnitt in einer Präsentation zusammenführen:
```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getSections().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```


Die Folie wird am Ende des Abschnitts eingefügt. 

{{% alert title="Tip" color="primary" %}}

Aspose bietet eine [KOSTENLOSE Collage‑Web‑App](https://products.aspose.app/slides/collage). Mit diesem Online‑Dienst können Sie [JPG zu JPG](https://products.aspose.app/slides/collage/jpg) oder PNG zu PNG‑Bilder zusammenführen, [Fotogitter](https://products.aspose.app/slides/collage/photo-grid) erstellen und vieles mehr. 

{{% /alert %}}

## **FAQ**

**Gibt es Begrenzungen für die Anzahl der Folien beim Zusammenführen von Präsentationen?**

Keine strikten Begrenzungen. Aspose.Slides kann große Dateien verarbeiten, jedoch hängt die Leistung von Dateigröße und Systemressourcen ab. Für sehr große Präsentationen wird empfohlen, eine 64‑Bit‑JVM zu verwenden und ausreichend Heap‑Speicher zuzuweisen.

**Kann ich Präsentationen mit eingebettetem Video oder Audio zusammenführen?**

Ja, Aspose.Slides bewahrt multimediale Inhalte, die in Folien eingebettet sind, jedoch kann die resultierende Präsentation deutlich größer werden.

**Werden Schriftarten beim Zusammenführen von Präsentationen erhalten bleiben?**

Ja. Schriftarten, die in den Quellpräsentationen verwendet werden, bleiben im Ausgabedokument erhalten, sofern sie auf dem System installiert oder [embedded](/slides/de/androidjava/embedded-font/) sind.