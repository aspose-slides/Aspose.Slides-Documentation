---
title: Efficientes Zusammenführen von Präsentationen auf Android
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
description: "Müheloses Zusammenführen von PowerPoint‑ (PPT, PPTX) und OpenDocument‑ (ODP) Präsentationen mit Aspose.Slides für Android via Java, um Ihren Arbeitsablauf zu optimieren."
---

{{% alert  title="Tipp" color="primary" %}} 

Vielleicht möchten Sie die **Aspose kostenlos online** [Merger‑App](https://products.aspose.app/slides/merger) ausprobieren. Sie ermöglicht es, PowerPoint‑Präsentationen im gleichen Format (PPT zu PPT, PPTX zu PPTX usw.) sowie Präsentationen in verschiedenen Formaten (PPT zu PPTX, PPTX zu ODP usw.) zusammenzuführen.

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **Präsentationszusammenführung**

Wenn Sie eine Präsentation mit einer anderen zusammenführen, kombinieren Sie damit effektiv deren Folien in einer einzigen Präsentation, um eine Datei zu erhalten. 

{{% alert title="Info" color="info" %}}

Die meisten Präsentationsprogramme (PowerPoint oder OpenOffice) verfügen nicht über Funktionen, die es Benutzern ermöglichen, Präsentationen auf diese Weise zu kombinieren. 

[**Aspose.Slides für Android via Java**](https://products.aspose.com/slides/androidjava/), ermöglicht jedoch das Zusammenführen von Präsentationen auf verschiedene Arten. Sie können Präsentationen mit allen ihren Formen, Stilen, Texten, Formatierungen, Kommentaren, Animationen usw. zusammenführen, ohne sich um Qualitäts- oder Datenverlust sorgen zu müssen.

**Siehe auch**

[Folien klonen](https://docs.aspose.com/slides/androidjava/clone-slides/).

{{% /alert %}}

### **Was kann zusammengeführt werden**

Mit Aspose.Slides können Sie Folgendes zusammenführen:

* gesamte Präsentationen. Alle Folien der Präsentationen landen in einer einzigen Präsentation
* spezifische Folien. Ausgewählte Folien landen in einer einzigen Präsentation
* Präsentationen in einem Format (PPT zu PPT, PPTX zu PPTX usw.) und in verschiedenen Formaten (PPT zu PPTX, PPTX zu ODP usw.) miteinander. 

### **Zusammenführungsoptionen**

Sie können Optionen festlegen, die bestimmen, ob

* jede Folie in der Ausgabepäsentation einen eindeutigen Stil beibehält
* ein bestimmter Stil für alle Folien in der Ausgabepäsentation verwendet wird. 

Um Präsentationen zusammenzuführen, stellt Aspose.Slides [AddClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)‑Methoden (aus dem [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection)‑Interface) bereit. Es gibt mehrere Implementierungen der `AddClone`‑Methoden, die die Parameter des Zusammenführungsprozesses definieren. Jedes Presentation‑Objekt besitzt eine [Slides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--)‑Sammlung, sodass Sie die `AddClone`‑Methode der Präsentation aufrufen können, zu der Sie Folien zusammenführen möchten.

Die `AddClone`‑Methode gibt ein `ISlide`‑Objekt zurück, das ein Klon der Quellfolie ist. Die Folien in einer Ausgabepäsentation sind einfach eine Kopie der Folien aus der Quelle. Daher können Sie die resultierenden Folien ändern (z. B. Stile, Formatierungsoptionen oder Layouts anwenden), ohne dass die Quellpräsentationen beeinflusst werden. 

## **Präsentationen zusammenführen** 

Aspose.Slides bietet die Methode [**AddClone(ISlide)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) an, mit der Sie Folien kombinieren können, wobei die Folien ihre Layouts und Stile beibehalten (Standard­parameter).

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

Aspose.Slides stellt die Methode [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) bereit, mit der Sie Folien kombinieren können, wobei eine Folienmaster‑Präsentationsvorlage angewendet wird. Auf diese Weise können Sie bei Bedarf den Stil der Folien in der Ausgabepäsentation ändern.

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


{{% alert title="Hinweis" color="warning" %}} 

Das Folienlayout für den Folienmaster wird automatisch ermittelt. Wenn kein passendes Layout ermittelt werden kann und der boolesche Parameter `allowCloneMissingLayout` der `AddClone`‑Methode auf true gesetzt ist, wird das Layout der Quellfolie verwendet. Andernfalls wird eine [PptxEditException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PptxEditException) ausgelöst.

{{% /alert %}}

Wenn die Folien in der Ausgabepäsentation ein anderes Folienlayout erhalten sollen, verwenden Sie stattdessen beim Zusammenführen die Methode [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-). 

## **Bestimmte Folien aus Präsentationen zusammenführen** 

Das Zusammenführen bestimmter Folien aus mehreren Präsentationen ist nützlich, um individuelle Foliensets zu erstellen. Aspose.Slides für Android via Java ermöglicht es, nur die benötigten Folien auszuwählen und zu importieren. Die API bewahrt die Formatierung, das Layout und das Design der Originalfolien.

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

{{% alert title="Hinweis" color="warning" %}} 

Sie können keine Präsentationen mit unterschiedlichen Foliengrößen zusammenführen. 

{{% /alert %}}

Um zwei Präsentationen mit unterschiedlichen Foliengrößen zusammenzuführen, müssen Sie eine der Präsentationen auf die Größe der anderen anpassen. 

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


Die Folie wird am Ende des Abschnitts hinzugefügt. 

{{% alert title="Tipp" color="primary" %}}

Aspose bietet eine [KOSTENLOSE Collage-Web‑App](https://products.aspose.app/slides/collage). Mit diesem Online‑Dienst können Sie [JPG zu JPG](https://products.aspose.app/slides/collage/jpg)‑ oder PNG‑zu‑PNG‑Bilder zusammenführen, [Fotogitter](https://products.aspose.app/slides/collage/photo-grid) erstellen und vieles mehr. 

{{% /alert %}}

## **FAQ**

**Gibt es Einschränkungen hinsichtlich der Folienzahl beim Zusammenführen von Präsentationen?**

Keine festen Einschränkungen. Aspose.Slides kann große Dateien verarbeiten, aber die Leistung hängt von der Größe und den Systemressourcen ab. Für sehr große Präsentationen wird empfohlen, eine 64‑Bit‑JVM zu verwenden und ausreichend Heap‑Speicher zuzuweisen.

**Kann ich Präsentationen mit eingebettetem Video oder Audio zusammenführen?**

Ja, Aspose.Slides bewahrt multimediale Inhalte, die in Folien eingebettet sind, jedoch kann die endgültige Präsentation deutlich größer werden.

**Werden Schriftarten beim Zusammenführen von Präsentationen erhalten bleiben?**

Ja. In Quellpräsentationen verwendete Schriftarten werden im Ausgabedokument erhalten, vorausgesetzt, sie sind im System installiert oder [eingebettet](/slides/de/androidjava/embedded-font/).