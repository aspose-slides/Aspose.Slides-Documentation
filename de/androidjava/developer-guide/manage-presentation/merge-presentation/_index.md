---
title: Effizientes Zusammenführen von Präsentationen auf Android
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

{{% alert  title="Hinweis" color="primary" %}} 

Vielleicht möchten Sie die **Aspose free online** [Merger app](https://products.aspose.app/slides/merger) ausprobieren. Sie ermöglicht das Zusammenführen von PowerPoint-Präsentationen im gleichen Format (PPT zu PPT, PPTX zu PPTX usw.) und das Zusammenführen von Präsentationen in unterschiedlichen Formaten (PPT zu PPTX, PPTX zu ODP usw.).

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **Präsentationszusammenführung**

Wenn Sie eine Präsentation mit einer anderen zusammenführen, kombinieren Sie deren Folien zu einer einzigen Präsentation, um eine Datei zu erhalten. 

{{% alert title="Info" color="info" %}}

Die meisten Präsentationsprogramme (PowerPoint oder OpenOffice) besitzen keine Funktionen, mit denen Benutzer Präsentationen auf diese Weise kombinieren können. 

[**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/androidjava/), ermöglicht jedoch das Zusammenführen von Präsentationen auf verschiedene Arten. Sie können Präsentationen mit allen ihren Formen, Stilen, Texten, Formatierungen, Kommentaren, Animationen usw. zusammenführen, ohne Qualitäts- oder Datenverlust befürchten zu müssen.

**Siehe auch**

[Clone Slides](https://docs.aspose.com/slides/androidjava/clone-slides/).

{{% /alert %}}

### **Was kann zusammengeführt werden**

Mit Aspose.Slides können Sie Folgendes zusammenführen: 

* gesamte Präsentationen. Alle Folien aus den Präsentationen werden zu einer einzigen Präsentation zusammengeführt
* bestimmte Folien. Ausgewählte Folien werden zu einer einzigen Präsentation zusammengeführt
* Präsentationen in einem Format (PPT zu PPT, PPTX zu PPTX usw.) sowie in unterschiedlichen Formaten (PPT zu PPTX, PPTX zu ODP usw.) miteinander. 

{{% alert title="Hinweis" color="warning" %}} 

Zusätzlich zu Präsentationen ermöglicht Aspose.Slides das Zusammenführen anderer Dateien:

* [Images](https://products.aspose.com/slides/androidjava/merger/image-to-image/), wie z. B. [JPG to JPG](https://products.aspose.com/slides/androidjava/merger/jpg-to-jpg/) oder [PNG to PNG](https://products.aspose.com/slides/androidjava/merger/png-to-png/)
* [Documents](https://products.aspose.com/slides/androidjava/merger/document-to-document/), wie z. B. [PDF to PDF](https://products.aspose.com/slides/androidjava/merger/pdf-to-pdf/) oder [HTML to HTML](https://products.aspose.com/slides/androidjava/merger/html-to-html/)
* Und zwei verschiedene Dateitypen, wie z. B. [image to PDF](https://products.aspose.com/slides/androidjava/merger/image-to-pdf/), [JPG to PDF](https://products.aspose.com/slides/androidjava/merger/jpg-to-pdf/) oder [TIFF to PDF](https://products.aspose.com/slides/androidjava/merger/tiff-to-pdf/).

{{% /alert %}}

### **Zusammenführungsoptionen**

Sie können Optionen festlegen, die bestimmen, ob

* jede Folie in der Ausgabepresentation einen einzigartigen Stil beibehält
* ein bestimmter Stil für alle Folien in der Ausgabepresentation verwendet wird. 

Um Präsentationen zusammenzuführen, stellt Aspose.Slides die [AddClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) Methoden (aus dem [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection) Interface) bereit. Es gibt mehrere Implementierungen der `AddClone`‑Methoden, die die Parameter des Zusammenführungsprozesses definieren. Jedes Presentation‑Objekt besitzt eine [Slides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--)‑Sammlung, sodass Sie eine `AddClone`‑Methode von der Präsentation aus aufrufen können, in die Sie Folien einfügen möchten.

Die `AddClone`‑Methode gibt ein `ISlide`‑Objekt zurück, das eine Kopie der Quellfolie ist. Die Folien in der Ausgabepresentation sind einfach Kopien der Quellfolien. Daher können Sie die resultierenden Folien (z. B. Stile, Formatierungsoptionen oder Layouts) ändern, ohne dass die Quellpräsentationen beeinflusst werden. 

## **Präsentationen zusammenführen** 

Aspose.Slides stellt die [**AddClone(ISlide)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) Methode bereit, die das Kombinieren von Folien ermöglicht, wobei die Folien ihre Layouts und Stile beibehalten (Standardparameter).

Dieser Java‑Code zeigt, wie Sie Präsentationen zusammenführen:
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

Aspose.Slides stellt die [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) Methode bereit, die das Kombinieren von Folien ermöglicht, wobei ein Folienmaster‑Vorlagendokument angewendet wird. Auf diese Weise können Sie bei Bedarf den Stil der Folien in der Ausgabepresentation ändern.

Dieser Java‑Code demonstriert die beschriebene Vorgangsweise:
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


{{% alert title="Hinweis" color="warning" %}} 

Das Layout für den Folienmaster wird automatisch ermittelt. Wenn kein geeignetes Layout ermittelt werden kann und der boolesche Parameter `allowCloneMissingLayout` der `AddClone`‑Methode auf **true** gesetzt ist, wird das Layout der Quellfolie verwendet. Andernfalls wird eine [PptxEditException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PptxEditException) ausgelöst.

{{% /alert %}}

Wenn Sie möchten, dass die Folien in der Ausgabepresentation ein anderes Folienlayout erhalten, verwenden Sie stattdessen die [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) Methode beim Zusammenführen.

## **Bestimmte Folien aus Präsentationen zusammenführen**

Das Zusammenführen ausgewählter Folien aus mehreren Präsentationen ist nützlich, um benutzerdefinierte Foliensets zu erstellen. Aspose.Slides for Android via Java ermöglicht das Auswählen und Importieren nur der benötigten Folien. Die API bewahrt Formatierung, Layout und Design der Originalfolien.

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

Dieser Java‑Code zeigt, wie Sie Folien aus Präsentationen kombinieren und dabei ein bevorzugtes Folienlayout anwenden, um eine einzige Ausgabepresentation zu erhalten:
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

{{% alert title="Hinweis" color="warning" %}} 

Sie können keine Präsentationen mit unterschiedlichen Foliengrößen zusammenführen. 

{{% /alert %}}

Um 2 Präsentationen mit unterschiedlichen Foliengrößen zusammenzuführen, müssen Sie die Größe einer Präsentation an die Größe der anderen anpassen. 

Dieser Beispielcode demonstriert die beschriebene Vorgehensweise:
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

Dieser Java‑Code zeigt, wie Sie eine bestimmte Folie zu einem Abschnitt einer Präsentation hinzufügen:
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

{{% alert title="Hinweis" color="primary" %}}

Aspose bietet eine [FREE Collage web app](https://products.aspose.app/slides/collage). Mit diesem Onlinedienst können Sie [JPG to JPG](https://products.aspose.app/slides/collage/jpg) oder PNG zu PNG Bilder zusammenführen, [photo grids](https://products.aspose.app/slides/collage/photo-grid) erstellen und vieles mehr. 

{{% /alert %}}

## **FAQ**

**Gibt es Begrenzungen für die Anzahl der Folien beim Zusammenführen von Präsentationen?**

Keine strengen Begrenzungen. Aspose.Slides kann große Dateien verarbeiten, die Leistung hängt jedoch von Dateigröße und Systemressourcen ab. Für sehr große Präsentationen wird empfohlen, eine 64‑Bit‑JVM zu verwenden und ausreichend Heap‑Speicher zuzuweisen.

**Kann ich Präsentationen mit eingebetteten Video‑ oder Audiodateien zusammenführen?**

Ja, Aspose.Slides bewahrt multimediale Inhalte, die in Folien eingebettet sind, jedoch kann die resultierende Präsentation deutlich größer werden.

**Werden Schriftarten beim Zusammenführen von Präsentationen erhalten?**

Ja. Schriftarten, die in den Quellpräsentationen verwendet werden, bleiben im Ausgabedokument erhalten, vorausgesetzt, sie sind im System installiert oder [embedded](/slides/de/androidjava/embedded-font/).