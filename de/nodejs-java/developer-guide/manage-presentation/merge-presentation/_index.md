---
title: Präsentationen effizient in JavaScript zusammenführen
linktitle: Präsentationen zusammenführen
type: docs
weight: 40
url: /de/nodejs-java/merge-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Müheloses Zusammenführen von PowerPoint (PPT, PPTX) und OpenDocument (ODP)-Präsentationen in JavaScript mit Aspose.Slides für Node.js, um Ihren Arbeitsablauf zu optimieren."
---

## **Präsentationszusammenführung**

Wenn Sie eine Präsentation mit einer anderen zusammenführen, kombinieren Sie effektiv deren Folien in einer einzigen Präsentation, um eine Datei zu erhalten. 

{{% alert title="Info" color="info" %}}

Die meisten Präsentationsprogramme (PowerPoint oder OpenOffice) besitzen keine Funktionen, die es Benutzern ermöglichen, Präsentationen auf diese Weise zu kombinieren. 

[**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/nodejs-java/), ermöglicht es Ihnen jedoch, Präsentationen auf verschiedene Arten zusammenzuführen. Sie können Präsentationen mit all ihren Formen, Stilen, Texten, Formatierungen, Kommentaren, Animationen usw. zusammenführen, ohne sich um Qualitäts- oder Datenverlust sorgen zu müssen.

**Siehe auch**

[Clone Slides](https://docs.aspose.com/slides/nodejs-java/clone-slides/).

{{% /alert %}}

### **Was kann zusammengeführt werden**

Mit Aspose.Slides können Sie zusammenführen 

* gesamte Präsentationen. Alle Folien aus den Präsentationen landen in einer einzigen Präsentation
* bestimmte Folien. Ausgewählte Folien landen in einer einzigen Präsentation
* Präsentationen in einem Format (PPT zu PPT, PPTX zu PPTX, etc.) und in unterschiedlichen Formaten (PPT zu PPTX, PPTX zu ODP, etc.) miteinander. 

### **Zusammenführungsoptionen**

Sie können Optionen anwenden, die bestimmen, ob

* jede Folie in der Ausgabepäsentation einen einzigartigen Stil beibehält
* ein bestimmter Stil für alle Folien in der Ausgabepäsentation verwendet wird. 

Um Präsentationen zusammenzuführen, stellt Aspose.Slides die [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-)‑Methoden (aus der [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection)‑Klasse) bereit. Es gibt mehrere Implementierungen der `addClone`‑Methoden, die die Parameter des Präsentationszusammenführungsprozesses festlegen. Jedes Presentation‑Objekt besitzt eine Slides‑Sammlung, sodass Sie die `addClone`‑Methode von der Präsentation aus aufrufen können, zu der Sie Folien zusammenführen möchten.

Die `addClone`‑Methode gibt ein `Slide`‑Objekt zurück, das eine Kopie der Quellfolie ist. Die Folien in einer Ausgabepäsentation sind einfach eine Kopie der Folien aus der Quelle. Daher können Sie Änderungen an den resultierenden Folien vornehmen (z. B. Stile, Formatierungsoptionen oder Layouts anwenden), ohne dass die Quellpräsentationen betroffen werden. 

## **Präsentationen zusammenführen** 

Aspose.Slides stellt die [**AddClone(ISlide)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-)‑Methode bereit, die es ermöglicht, Folien zu kombinieren, wobei die Folien ihre Layouts und Stile beibehalten (Standardparameter).

Dieser JavaScript‑Code zeigt, wie Sie Präsentationen zusammenführen:
```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```


## **Präsentationen mit Folienmaster zusammenführen**

Aspose.Slides stellt die [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-)‑Methode bereit, die es ermöglicht, Folien zu kombinieren und dabei eine Folienmaster‑Präsentationsvorlage anzuwenden. Auf diese Weise können Sie bei Bedarf den Stil der Folien in der Ausgabepäsentation ändern.

Dieser JavaScript‑Code demonstriert den beschriebenen Vorgang:
```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres2.getMasters().get_Item(0), true);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```


{{% alert title="Note" color="warning" %}} 

Der Folienlayout für den Folienmaster wird automatisch bestimmt. Wenn kein geeignetes Layout bestimmt werden kann, wird bei gesetztem `allowCloneMissingLayout`‑Booleschen Parameter der `addClone`‑Methode das Layout der Quellfolie verwendet. Andernfalls wird eine [PptxEditException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PptxEditException) ausgelöst.

{{% /alert %}}

Wenn die Folien in der Ausgabepäsentation ein anderes Folienlayout erhalten sollen, verwenden Sie stattdessen die Methode [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) beim Zusammenführen.

## **Bestimmte Folien aus Präsentationen zusammenführen**

Das Zusammenführen bestimmter Folien aus mehreren Präsentationen ist nützlich, um benutzerdefinierte Folienpakete zu erstellen. Aspose.Slides für Node.js via Java ermöglicht es Ihnen, nur die benötigten Folien auszuwählen und zu importieren. Die API bewahrt Formatierung, Layout und Design der Originalfolien.

Der folgende JavaScript‑Code erstellt eine neue Präsentation, fügt Titelfolien aus zwei anderen Präsentationen hinzu und speichert das Ergebnis in einer Datei:
```js
function getTitleSlide(presentation) {
  for (let i = 0; i < presentation.getSlides().size(); i++) {
    let slide = presentation.getSlides().get_Item(i);
    if (slide.getLayoutSlide().getLayoutType() == aspose.slides.SlideLayoutType.Title) {
      return slide;
    }
  }
  return null;
}
```

```js
let presentation = new aspose.slides.Presentation();
let presentation1 = new aspose.slides.Presentation("presentation1.pptx");
let presentation2 = new aspose.slides.Presentation("presentation2.pptx");
try {
    presentation.getSlides().removeAt(0);
    
    let slide1 = getTitleSlide(presentation1);

    if (slide1 != null)
        presentation.getSlides().addClone(slide1);

    let slide2 = getTitleSlide(presentation2);

    if (slide2 != null)
        presentation.getSlides().addClone(slide2);

    presentation.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
    presentation.dispose();
}
```


## **Präsentationen mit Folienlayout zusammenführen**

Dieser JavaScript‑Code zeigt, wie Sie Folien aus Präsentationen kombinieren und dabei Ihr bevorzugtes Folienlayout anwenden, um eine einzige Ausgabepäsentation zu erhalten:
```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres2.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```


## **Präsentationen mit unterschiedlichen Foliengrößen zusammenführen**

{{% alert title="Note" color="warning" %}} 

Sie können Präsentationen mit unterschiedlichen Foliengrößen nicht zusammenführen. 

{{% /alert %}}

Um 2 Präsentationen mit unterschiedlichen Foliengrößen zusammenzuführen, müssen Sie eine der Präsentationen so skalieren, dass ihre Größe der der anderen Präsentation entspricht. 

Dieser Beispielcode demonstriert den beschriebenen Vorgang:
```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        pres2.getSlideSize().setSize(pres1.getSlideSize().getSize().getWidth(), pres1.getSlideSize().getSize().getHeight(), aspose.slides.SlideSizeScaleType.EnsureFit);
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```


## **Folien zu einem Präsentationsabschnitt zusammenführen**

Dieser JavaScript‑Code zeigt, wie Sie eine bestimmte Folie zu einem Abschnitt in einer Präsentation zusammenführen:
```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres1.getSections().get_Item(0));
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```


Die Folie wird am Ende des Abschnitts eingefügt. 

## **FAQ**

**Werden Sprecher‑Notizen beim Zusammenführen erhalten?**

Ja. Beim Klonen von Folien übernimmt Aspose.Slides alle Folienelemente, einschließlich Notizen, Formatierungen und Animationen.

**Werden Kommentare und deren Autoren übertragen?**

Kommentare, als Teil des Folieninhalts, werden mit der Folie kopiert. Kommentar‑Autor‑Labels werden als Kommentarobjekte in der resultierenden Präsentation erhalten.

**Was ist, wenn die Quellpräsentation passwortgeschützt ist?**

Sie muss [mit dem Passwort geöffnet](/slides/de/nodejs-java/password-protected-presentation/) über [LoadOptions.setPassword](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/setpassword/) werden; nach dem Laden können diese Folien sicher in eine ungeschützte Zieldatei (oder ebenfalls geschützt) geklont werden.

**Wie thread‑sicher ist der Zusammenführungs­vorgang?**

Verwenden Sie nicht dieselbe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)‑Instanz aus mehreren Threads. Die empfohlene Regel lautet „ein Dokument – ein Thread“; verschiedene Dateien können parallel in separaten Threads bearbeitet werden.

## **Siehe auch**

Aspose bietet einen [KOSTENLOSEN Online‑Collage‑Maker](https://products.aspose.app/slides/collage). Mit diesem Online‑Dienst können Sie JPG‑zu‑JPG‑ oder PNG‑zu‑PNG‑Bilder zusammenführen, Fotogitter erstellen und mehr.

Probieren Sie den Aspose **KOSTENLOSEN Online‑Zusammenführer** aus. Er ermöglicht das Zusammenführen von PowerPoint‑Präsentationen im selben Format (z. B. PPT zu PPT, PPTX zu PPTX) oder über verschiedene Formate hinweg (z. B. PPT zu PPTX, PPTX zu ODP).

[![Aspose FREE Online Merger](slides-merger.png)](https://products.aspose.app/slides/merger)