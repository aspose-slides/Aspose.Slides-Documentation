---
title: Präsentation zusammenführen
type: docs
weight: 40
url: /de/nodejs-java/merge-presentation/
keywords: "PowerPoint zusammenführen, PPTX, PPT, PowerPoint kombinieren, Präsentation zusammenführen, Präsentation kombinieren, Java"
description: "PowerPoint‑Präsentation in JavaScript zusammenführen oder kombinieren"
---

## **Präsentationszusammenführung**

Wenn Sie eine Präsentation mit einer anderen zusammenführen, kombinieren Sie praktisch deren Folien zu einer einzigen Präsentation, um eine Datei zu erhalten. 

{{% alert title="Info" color="info" %}}

Die meisten Präsentationsprogramme (PowerPoint oder OpenOffice) verfügen nicht über Funktionen, die es Benutzern ermöglichen, Präsentationen auf diese Weise zu kombinieren. 

[**Aspose.Slides für Node.js via Java**](https://products.aspose.com/slides/nodejs-java/), ermöglicht jedoch das Zusammenführen von Präsentationen auf verschiedene Arten. Sie können Präsentationen mit all ihren Formen, Stilen, Texten, Formatierungen, Kommentaren, Animationen usw. zusammenführen, ohne sich um Qualitäts- oder Datenverlust Sorgen machen zu müssen.

**Siehe auch**

[Folien klonen](https://docs.aspose.com/slides/nodejs-java/clone-slides/).

{{% /alert %}}

### **Was kann zusammengeführt werden**

Mit Aspose.Slides können Sie zusammenführen 

* gesamte Präsentationen. Alle Folien aus den Präsentationen werden in einer Präsentation zusammengeführt
* bestimmte Folien. Ausgewählte Folien werden in einer Präsentation zusammengeführt
* Präsentationen in einem Format (PPT zu PPT, PPTX zu PPTX usw.) und in verschiedenen Formaten (PPT zu PPTX, PPTX zu ODP usw.) miteinander. 

{{% alert title="Hinweis" color="warning" %}} 

Neben Präsentationen ermöglicht Aspose.Slides das Zusammenführen anderer Dateien:

* [Bilder](https://products.aspose.com/slides/nodejs-java/merger/image-to-image/), wie z. B. [JPG zu JPG](https://products.aspose.com/slides/nodejs-java/merger/jpg-to-jpg/) oder [PNG zu PNG](https://products.aspose.com/slides/nodejs-java/merger/png-to-png/)
* Dokumente, wie z. B. [PDF zu PDF](https://products.aspose.com/slides/nodejs-java/merger/pdf-to-pdf/) oder [HTML zu HTML](https://products.aspose.com/slides/nodejs-java/merger/html-to-html/)
* Und zwei unterschiedliche Dateien, wie z. B. [Bild zu PDF](https://products.aspose.com/slides/nodejs-java/merger/image-to-pdf/) oder [JPG zu PDF](https://products.aspose.com/slides/nodejs-java/merger/jpg-to-pdf/) oder [TIFF zu PDF](https://products.aspose.com/slides/nodejs-java/merger/tiff-to-pdf/).

{{% /alert %}}

### **Zusammenführungsoptionen**

Sie können Optionen anwenden, die bestimmen, ob

* jede Folie in der Ausgabepäsentation einen eindeutigen Stil beibehält
* ein bestimmter Stil für alle Folien in der Ausgabepäsentation verwendet wird. 

Um Präsentationen zusammenzuführen, stellt Aspose.Slides die [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-)‑Methoden (aus der [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection)-Klasse) bereit. Es gibt mehrere Implementierungen der `addClone`‑Methoden, die die Parameter des Zusammenführungsprozesses definieren. Jedes Presentation‑Objekt besitzt eine [Slides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--)‑Sammlung, sodass Sie die `addClone`‑Methode von der Präsentation aus aufrufen können, in die Sie Folien einfügen möchten.

Die `addClone`‑Methode gibt ein `Slide`‑Objekt zurück, das eine Kopie der Quellfolie ist. Die Folien in einer Ausgabepäsentation sind einfach Kopien der Folien aus der Quelle. Daher können Sie die resultierenden Folien ändern (z. B. Stile, Formatierungsoptionen oder Layouts anwenden), ohne dass die Quellpräsentationen beeinflusst werden. 

## **Präsentationen zusammenführen** 

Aspose.Slides stellt die [**AddClone(ISlide)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-)‑Methode bereit, die das Kombinieren von Folien ermöglicht, während die Folien ihre Layouts und Stile beibehalten (Standardparameter).

Dieser JavaScript‑Code zeigt, wie Präsentationen zusammengeführt werden:
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

Aspose.Slides stellt die [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-)‑Methode bereit, die das Kombinieren von Folien ermöglicht, wobei eine Folienmaster‑Vorlage angewendet wird. Auf diese Weise können Sie bei Bedarf den Stil der Folien in der Ausgabepäsentation ändern.

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


{{% alert title="Hinweis" color="warning" %}} 

Das Folienlayout für den Folienmaster wird automatisch ermittelt. Wenn kein geeignetes Layout ermittelt werden kann und der boolesche Parameter `allowCloneMissingLayout` der `addClone`‑Methode auf true gesetzt ist, wird das Layout der Quellfolie verwendet. Andernfalls wird eine [PptxEditException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PptxEditException) ausgelöst.

{{% /alert %}}

Wenn Sie möchten, dass die Folien in der Ausgabepäsentation ein anderes Folienlayout erhalten, verwenden Sie stattdessen die [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-)‑Methode beim Zusammenführen.

## **Bestimmte Folien aus Präsentationen zusammenführen**

Das Zusammenführen bestimmter Folien aus mehreren Präsentationen ist nützlich, um benutzerdefinierte Foliensätze zu erstellen. Aspose.Slides für Node.js via Java ermöglicht das Auswählen und Importieren nur der benötigten Folien. Die API bewahrt Formatierung, Layout und Design der Originalfolien.

Der folgende JavaScript‑Code erzeugt eine neue Präsentation, fügt Titelfolien aus zwei anderen Präsentationen hinzu und speichert das Ergebnis in einer Datei:
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

Dieser JavaScript‑Code zeigt, wie Folien aus Präsentationen kombiniert werden, während ein bevorzugtes Folienlayout angewendet wird, um eine Ausgabepäsentation zu erhalten:
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

{{% alert title="Hinweis" color="warning" %}} 

Sie können keine Präsentationen mit unterschiedlichen Foliengrößen zusammenführen. 

{{% /alert %}}

Um 2 Präsentationen mit unterschiedlichen Foliengrößen zusammenzuführen, müssen Sie eine der Präsentationen skalieren, sodass ihre Größe der der anderen Präsentation entspricht. 

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


## **Folien in Präsentationsabschnitt zusammenführen**

Dieser JavaScript‑Code zeigt, wie Sie eine bestimmte Folie in einen Abschnitt einer Präsentation zusammenführen:
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

**Werden Notizen beim Zusammenführen erhalten?**

Ja. Beim Klonen von Folien übernimmt Aspose.Slides alle Folienelemente, einschließlich Notizen, Formatierungen und Animationen.

**Werden Kommentare und deren Autoren übertragen?**

Kommentare, als Teil des Folieninhalts, werden mit der Folie kopiert. Kommentare‑Autor‑Labels bleiben als Kommentarobjekte in der resultierenden Präsentation erhalten.

**Was ist, wenn die Quellpräsentation passwortgeschützt ist?**

Sie muss [mit dem Passwort geöffnet werden](/slides/de/nodejs-java/password-protected-presentation/) über [LoadOptions.setPassword](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/setpassword/); nach dem Laden können diese Folien sicher in eine ungeschützte Zieldatei (oder ebenfalls in eine geschützte) geklont werden.

**Wie thread‑sicher ist der Zusammenführungsvorgang?**

Verwenden Sie nicht dieselbe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)‑Instanz aus [mehreren Threads](/slides/de/nodejs-java/multithreading/). Die empfohlene Regel lautet „ein Dokument – ein Thread“; verschiedene Dateien können parallel in separaten Threads verarbeitet werden.

## **Siehe auch**

Aspose bietet einen [KOSTENLOSEN Online‑Collage‑Ersteller](https://products.aspose.app/slides/collage). Mit diesem Online‑Dienst können Sie [JPG zu JPG](https://products.aspose.app/slides/collage/jpg) oder PNG zu PNG‑Bilder zusammenführen, [Fotogitter](https://products.aspose.app/slides/collage/photo-grid) erstellen und mehr.

Probieren Sie den [Aspose KOSTENLOSEN Online‑Zusammenführer](https://products.aspose.app/slides/merger). Er ermöglicht das Zusammenführen von PowerPoint‑Präsentationen im gleichen Format (z. B. PPT zu PPT, PPTX zu PPTX) oder über verschiedene Formate hinweg (z. B. PPT zu PPTX, PPTX zu ODP).

[![Aspose KOSTENLOSER Online‑Zusammenführer](slides-merger.png)](https://products.aspose.app/slides/merger)