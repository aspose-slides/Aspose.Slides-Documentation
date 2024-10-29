---
title: Präsentationen zusammenführen
type: docs
weight: 40
url: /de/androidjava/merge-presentation/
keywords: "PowerPoint zusammenführen, PPTX, PPT, PowerPoint kombinieren, Präsentation zusammenführen, Präsentation kombinieren, Java"
description: "PowerPoint-Präsentationen in Java zusammenführen oder kombinieren"
---


{{% alert  title="Tipp" color="primary" %}} 

Sie möchten vielleicht die **Aspose kostenlose Online** [Merger-App](https://products.aspose.app/slides/merger) ausprobieren. Damit können Benutzer PowerPoint-Präsentationen im selben Format (PPT zu PPT, PPTX zu PPTX usw.) und Präsentationen in unterschiedlichen Formaten (PPT zu PPTX, PPTX zu ODP usw.) zusammenführen.

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **Präsentationen Zusammenführen**

Wenn Sie eine Präsentation mit einer anderen zusammenführen, kombinieren Sie effektiv deren Folien in einer einzigen Präsentation, um eine Datei zu erhalten. 

{{% alert title="Info" color="info" %}}

Die meisten Präsentationsprogramme (PowerPoint oder OpenOffice) haben keine Funktionen, die es Benutzern ermöglichen, Präsentationen auf diese Weise zu kombinieren.

[**Aspose.Slides für Android über Java**](https://products.aspose.com/slides/androidjava/), erlaubt jedoch das Zusammenführen von Präsentationen auf verschiedene Arten. Sie können Präsentationen mit all ihren Formen, Stilen, Texten, Formatierungen, Kommentaren, Animationen usw. zusammenführen, ohne sich um den Verlust von Qualität oder Daten sorgen zu müssen.

**Siehe auch**

[Folien klonen](https://docs.aspose.com/slides/androidjava/clone-slides/).

{{% /alert %}}

### **Was Kann Zusammengeführt Werden**

Mit Aspose.Slides können Sie 

* gesamte Präsentationen. Alle Folien der Präsentationen enden in einer Präsentation
* spezifische Folien. Ausgewählte Folien enden in einer Präsentation
* Präsentationen im gleichen Format (PPT zu PPT, PPTX zu PPTX usw.) und in unterschiedlichen Formaten (PPT zu PPTX, PPTX zu ODP usw.) miteinander.

{{% alert title="Hinweis" color="warning" %}} 

Neben Präsentationen ermöglicht Aspose.Slides auch das Zusammenführen anderer Dateien:

* [Bilder](https://products.aspose.com/slides/androidjava/merger/image-to-image/), wie [JPG zu JPG](https://products.aspose.com/slides/androidjava/merger/jpg-to-jpg/) oder [PNG zu PNG](https://products.aspose.com/slides/androidjava/merger/png-to-png/)
* Dokumente, wie [PDF zu PDF](https://products.aspose.com/slides/androidjava/merger/pdf-to-pdf/) oder [HTML zu HTML](https://products.aspose.com/slides/androidjava/merger/html-to-html/)
* Und zwei verschiedene Dateien wie [Bild zu PDF](https://products.aspose.com/slides/androidjava/merger/image-to-pdf/) oder [JPG zu PDF](https://products.aspose.com/slides/androidjava/merger/jpg-to-pdf/) oder [TIFF zu PDF](https://products.aspose.com/slides/androidjava/merger/tiff-to-pdf/).

{{% /alert %}}

### **Zusammenführungsoptionen**

Sie können Optionen anwenden, die bestimmen, ob

* jede Folie in der Ausgabpräsentation einen einzigartigen Stil beibehält
* ein spezifischer Stil für alle Folien in der Ausgabpräsentation verwendet wird. 

Um Präsentationen zusammenzuführen, bietet Aspose.Slides die [AddClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) Methoden (aus dem [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection) Interface). Es gibt mehrere Implementierungen der `AddClone` Methoden, die die Parameter des Präsentationszusammenführungsprozesses definieren. Jedes Präsentationsobjekt hat eine [Slides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) Sammlung, sodass Sie eine `AddClone` Methode von der Präsentation aufrufen können, mit der Sie Folien zusammenführen möchten.

Die `AddClone` Methode gibt ein `ISlide` Objekt zurück, welches ein Klon der Quellfolie ist. Die Folien in einer Ausgabpräsentation sind einfach eine Kopie der Folien aus der Quelle. Daher können Sie Änderungen an den resultierenden Folien vornehmen (zum Beispiel Stile oder Formatierungsoptionen oder Layouts anwenden), ohne sich um die Auswirkungen auf die Quellpräsentationen zu sorgen.

## **Präsentationen Zusammenführen** 

Aspose.Slides bietet die [**AddClone(ISlide)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) Methode, die es Ihnen ermöglicht, Folien zu kombinieren, während die Folien ihre Layouts und Stile beibehalten (Standardparameter).

Dieser Java-Code zeigt Ihnen, wie Sie Präsentationen zusammenführen:

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

## **Präsentationen mit Masterfolie Zusammenführen**

Aspose.Slides bietet die [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) Methode, die es Ihnen ermöglicht, Folien zu kombinieren, während eine Folienmaster-Präsentationsvorlage angewendet wird. So können Sie bei Bedarf den Stil für Folien in der Ausgabpräsentation ändern.

Dieser Code in Java demonstriert die beschriebene Operation:

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

Das Folienlayout für die Folienmaster wird automatisch bestimmt. Wenn ein passendes Layout nicht bestimmt werden kann, wird, wenn der boolean Parameter `allowCloneMissingLayout` der `AddClone` Methode auf true gesetzt ist, das Layout für die Quellfolie verwendet. Andernfalls wird eine [PptxEditException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PptxEditException) ausgelöst.

{{% /alert %}}

Wenn Sie möchten, dass die Folien in der Ausgabpräsentation ein anderes Folienlayout haben, verwenden Sie beim Zusammenführen stattdessen die [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) Methode.

## **Bestimmte Folien Aus Präsentationen Zusammenführen**

Dieser Java-Code zeigt Ihnen, wie Sie bestimmte Folien aus verschiedenen Präsentationen auswählen und kombinieren, um eine Ausgabpräsentation zu erhalten:

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

## **Präsentationen Mit Folienlayout Zusammenführen**

Dieser Java-Code zeigt Ihnen, wie Sie Folien aus Präsentationen kombinieren, während Sie Ihr bevorzugtes Folienlayout darauf anwenden, um eine Ausgabpräsentation zu erhalten:

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

## **Präsentationen Mit Unterschiedlichen Foliengrößen Zusammenführen**

{{% alert title="Hinweis" color="warning" %}} 

Sie können keine Präsentationen mit unterschiedlichen Foliengrößen zusammenführen. 

{{% /alert %}}

Um 2 Präsentationen mit unterschiedlichen Foliengrößen zusammenzuführen, müssen Sie eine der Präsentationen so ändern, dass ihre Größe der anderen Präsentation entspricht. 

Dieser Beispielcode demonstriert die beschriebene Operation:

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

## **Folien In Präsentationsabschnitt Zusammenführen**

Dieser Java-Code zeigt Ihnen, wie Sie eine spezifische Folie in einen Abschnitt einer Präsentation zusammenführen:

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

Die Folie wird am Ende des Abschnitts hinzugefügt. 

{{% alert title="Tipp" color="primary" %}}

Aspose bietet eine [KOSTENLOSE Collage-Webanwendung](https://products.aspose.app/slides/collage). Mit diesem Online-Service können Sie [JPG zu JPG](https://products.aspose.app/slides/collage/jpg) oder PNG zu PNG Bilder zusammenführen, [Fotogitter](https://products.aspose.app/slides/collage/photo-grid) erstellen usw. 

{{% /alert %}}