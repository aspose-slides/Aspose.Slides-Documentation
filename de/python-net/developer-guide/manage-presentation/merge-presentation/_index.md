---
title: Präsentation zusammenführen
type: docs
weight: 40
url: /de/python-net/merge-presentation/
keywords: "PowerPoint zusammenführen, PPTX, PPT, PowerPoint kombinieren, Präsentation zusammenführen, Präsentation kombinieren, Python"
description: "PowerPoint-Präsentationen in Python zusammenführen oder kombinieren"
---

{{% alert  title="Tipp" color="primary" %}} 

Sie möchten vielleicht die **Aspose kostenlose Online** [Merger-App](https://products.aspose.app/slides/merger) ausprobieren. Sie ermöglicht es, PowerPoint-Präsentationen im gleichen Format (PPT zu PPT, PPTX zu PPTX usw.) zusammenzuführen und Präsentationen in unterschiedlichen Formaten (PPT zu PPTX, PPTX zu ODP usw.) zu kombinieren.

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **Präsentationen zusammenführen**

Wenn Sie eine Präsentation mit einer anderen zusammenführen, kombinieren Sie effektiv deren Folien in einer einzigen Präsentation, um eine Datei zu erhalten. 

{{% alert title="Info" color="info" %}}

Die meisten Präsentationsprogramme (PowerPoint oder OpenOffice) verfügen nicht über Funktionen, die es den Benutzern ermöglichen, Präsentationen auf diese Weise zu kombinieren. 

[**Aspose.Slides für Python über .NET**](https://products.aspose.com/slides/python-net/) hingegen ermöglicht es Ihnen, Präsentationen auf unterschiedliche Weise zusammenzuführen. Sie können Präsentationen mit all ihren Formen, Stilen, Texten, Formatierungen, Kommentaren, Animationen usw. zusammenführen, ohne sich um den Verlust von Qualität oder Daten sorgen zu müssen. 

**Siehe auch**

[Folien klonen](https://docs.aspose.com/slides/python-net/cloning-commenting-and-manipulating-slides/#cloning-commentingandmanipulatingslides-cloningslides)*.* 

{{% /alert %}}

### **Was kann zusammengeführt werden**

Mit Aspose.Slides können Sie 

* ganze Präsentationen zusammenführen. Alle Folien aus den Präsentationen enden in einer Präsentation
* spezifische Folien zusammenführen. Ausgewählte Folien enden in einer Präsentation
* Präsentationen im gleichen Format (PPT zu PPT, PPTX zu PPTX usw.) und in unterschiedlichen Formaten (PPT zu PPTX, PPTX zu ODP usw.) miteinander kombinieren.

{{% alert title="Hinweis" color="warning" %}} 

Neben Präsentationen ermöglicht es Aspose.Slides Ihnen, andere Dateien zusammenzuführen:

* [Bilder](https://products.aspose.com/slides/python-net/merger/image-to-image/), wie [JPG zu JPG](https://products.aspose.com/slides/python-net/merger/jpg-to-jpg/) oder [PNG zu PNG](https://products.aspose.com/slides/python-net/merger/png-to-png/)
* Dokumente, wie [PDF zu PDF](https://products.aspose.com/slides/python-net/merger/pdf-to-pdf/) oder [HTML zu HTML](https://products.aspose.com/slides/python-net/merger/html-to-html/)
* Und zwei verschiedene Dateien wie [Bild zu PDF](https://products.aspose.com/slides/python-net/merger/image-to-pdf/) oder [JPG zu PDF](https://products.aspose.com/slides/python-net/merger/jpg-to-pdf/) oder [TIFF zu PDF](https://products.aspose.com/slides/python-net/merger/tiff-to-pdf/).

{{% /alert %}}

### **Zusammenführungsoptionen**

Sie können Optionen anwenden, die bestimmen, ob

* jede Folie in der Ausgabpräsentation einen einzigartigen Stil beibehält
* ein spezifischer Stil für alle Folien in der Ausgabpräsentation verwendet wird. 

Um Präsentationen zusammenzuführen, bietet Aspose.Slides [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) Methoden (aus dem [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) Interface). Es gibt mehrere Implementierungen der `add_clone` Methoden, die die Parameter des Präsentationen-Zusammenführungsprozesses definieren. Jedes Präsentationsobjekt hat eine [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Sammlung, so dass Sie eine `add_clone` Methode von der Präsentation aufrufen können, in die Sie Folien zusammenführen möchten. 

Die `add_clone` Methode gibt ein `ISlide` Objekt zurück, das ein Klon der Quellfolie ist. Die Folien in einer Ausgabpräsentation sind einfach Kopien der Folien aus der Quelle. Daher können Sie die resultierenden Folien ändern (zum Beispiel, Stile oder Formatierungsoptionen oder Layouts anwenden), ohne sich um die Beeinträchtigung der Quellpräsentationen sorgen zu müssen. 

## **Präsentationen zusammenführen** 

Aspose.Slides bietet die [**AddClone (ISlide)**](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) Methode, die es Ihnen ermöglicht, Folien zu kombinieren, während die Folien ihre Layouts und Stile beibehalten (Standardparameter). 

Dieser Python-Code zeigt Ihnen, wie Sie Präsentationen zusammenführen:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres1:
    with slides.Presentation("Presentation1.pptx") as pres2:
        for slide in pres2.slides:
            pres1.slides.add_clone(slide)
        pres1.save("combined.pptx", slides.export.SaveFormat.PPTX)
```

## **Präsentationen mit Folienmaster zusammenführen**

Aspose.Slides bietet die [**add_clone (ISlide, IMasterSlide, Boolean)**](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) Methode, die es Ihnen ermöglicht, Folien zu kombinieren und dabei eine Folienmaster-Präsentationsvorlage anzuwenden. Auf diese Weise können Sie bei Bedarf den Stil für Folien in der Ausgabpräsentation ändern. 

Dieser Code in Python demonstriert die beschriebene Operation:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres1:
    with slides.Presentation("Presentation1.pptx") as pres2:
        for slide in pres2.slides:
            pres1.slides.add_clone(slide, pres1.masters[0], allow_clone_missing_layout = True)
        pres1.save("combined_with_master.pptx", slides.export.SaveFormat.PPTX) 
```

{{% alert title="Hinweis" color="warning" %}} 

Das Folienlayout für den Folienmaster wird automatisch bestimmt. Wenn ein passendes Layout nicht bestimmt werden kann, wird, wenn der `allowCloneMissingLayout` boolesche Parameter der `add_clone` Methode auf true gesetzt ist, das Layout für die Quellfolie verwendet. Andernfalls wird eine [PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/) ausgelöst. 

{{% /alert %}}

Wenn Sie möchten, dass die Folien in der Ausgabpräsentation ein anderes Folienlayout haben, verwenden Sie stattdessen die [add_clone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) Methode beim Zusammenführen. 

## **Bestimmte Folien aus Präsentationen zusammenführen**

Dieser Python-Code zeigt Ihnen, wie Sie spezifische Folien aus verschiedenen Präsentationen auswählen und kombinieren, um eine Ausgabpräsentation zu erhalten:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres1:
    with slides.Presentation("Presentation1.pptx") as pres2:
        for slide in pres2.slides:
            pres1.slides.add_clone(slide, pres1.layout_slides[0])
        pres1.save("combined_with_layout.pptx", slides.export.SaveFormat.PPTX) 
```

## **Präsentationen mit Folienlayout zusammenführen**

Dieser Python-Code zeigt Ihnen, wie Sie Folien aus Präsentationen kombinieren und dabei Ihr bevorzugtes Folienlayout anwenden, um eine Ausgabpräsentation zu erhalten:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres1:
    with slides.Presentation("Presentation1.pptx") as pres2:
        for slide in pres2.slides:
            pres1.slides.add_clone(slide, pres1.layout_slides[0])
        pres1.save("combined_with_layout.pptx", slides.export.SaveFormat.PPTX) 
```

## **Präsentationen mit unterschiedlichen Foliengrößen zusammenführen**

{{% alert title="Hinweis" color="warning" %}} 

Sie können keine Präsentationen mit unterschiedlichen Foliengrößen zusammenführen. 

{{% /alert %}}

Um 2 Präsentationen mit unterschiedlichen Foliengrößen zusammenzuführen, müssen Sie eine der Präsentationen so skalieren, dass ihre Größe der der anderen Präsentation entspricht. 

Dieser Beispieldcode demonstriert die beschriebene Operation:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres1:
    with slides.Presentation("Presentation1.pptx") as pres2:
        pres2.slide_size.set_size(pres1.slide_size.size.width, pres1.slide_size.size.height, slides.SlideSizeScaleType.ENSURE_FIT)
        for slide in pres2.slides:
            pres1.slides.add_clone(slide)
        pres1.save("combined_size.pptx", slides.export.SaveFormat.PPTX) 
```

## **Folien zu einem Präsentationsabschnitt zusammenführen**

Dieser Python-Code zeigt Ihnen, wie Sie eine spezifische Folie in einen Abschnitt einer Präsentation zusammenführen:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres1:
    with slides.Presentation("Presentation1.pptx") as pres2:
        for slide in pres2.slides:
            pres1.slides.add_clone(slide, pres1.sections[0])
        pres1.save("combined_sections.pptx", slides.export.SaveFormat.PPTX) 
```

Die Folie wird am Ende des Abschnitts hinzugefügt. 

{{% alert title="Tipp" color="primary" %}}

Aspose bietet eine [KOSTENLOSE Collage-Web-App](https://products.aspose.app/slides/collage). Mit diesem Onlinedienst können Sie [JPG zu JPG](https://products.aspose.app/slides/collage/jpg) oder PNG zu PNG Bilder zusammenführen, [Foto-Raster](https://products.aspose.app/slides/collage/photo-grid) erstellen usw. 

{{% /alert %}}