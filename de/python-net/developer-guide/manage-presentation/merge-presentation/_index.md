---
title: Präsentationen effizient mit Python zusammenführen
linktitle: Präsentationen zusammenführen
type: docs
weight: 40
url: /de/python-net/developer-guide/manage-presentation/merge-presentation/
keywords:
- merge PowerPoint
- merge presentations
- merge slides
- merge PPT
- merge PPTX
- merge ODP
- combine PowerPoint
- combine presentations
- combine slides
- combine PPT
- combine PPTX
- combine ODP
- Python
- Aspose.Slides
description: "Müheloses Zusammenführen von PowerPoint (PPT, PPTX) und OpenDocument (ODP) Präsentationen mit Aspose.Slides für Python via .NET, um Ihren Arbeitsablauf zu optimieren."
---

## **Optimieren Sie das Zusammenführen Ihrer Präsentationen**

Mit [Aspose.Slides for Python](https://products.aspose.com/slides/python-net/) können Sie PowerPoint‑Präsentationen nahtlos kombinieren und dabei Stil, Layouts und alle Elemente beibehalten. Im Gegensatz zu anderen Tools fügt Aspose.Slides Präsentationen zusammen, ohne die Qualität zu beeinträchtigen oder Daten zu verlieren. Fügen Sie komplette Decks, bestimmte Folien oder sogar unterschiedliche Dateiformate zusammen (z. B. PPT zu PPTX).

### **Zusammenführungsfunktionen**

- **Komplettes Präsentationszusammenführen:** Alle Folien zu einer einzigen Datei zusammenstellen.
- **Spezifisches Folienzusammenführen:** Ausgewählte Folien auswählen und kombinieren.
- **Cross-Format-Zusammenführen:** Präsentationen verschiedener Formate integrieren und dabei die Integrität bewahren.

## **Präsentationszusammenführung**

Wenn Sie eine Präsentation in eine andere einfügen, kombinieren Sie deren Folien zu einer einzigen Präsentation, um eine Datei zu erzeugen. Die meisten Präsentationsprogramme – wie PowerPoint oder OpenOffice – bieten keine Funktionen, die ein solches Zusammenführen ermöglichen.

Mit [Aspose.Slides for Python](https://products.aspose.com/slides/python-net/) können Sie Präsentationen auf verschiedene Arten zusammenführen. Sie können Präsentationen mit allen Formen, Stilen, Texten, Formatierungen, Kommentaren und Animationen zusammenführen, ohne Qualitäts- oder Datenverlust.

**Siehe auch**

[Clone PowerPoint Slides in Python](/slides/de/python-net/clone-slides/)

### **Was kann zusammengeführt werden**

Mit Aspose.Slides können Sie zusammenführen:

- Ganze Präsentationen: Alle Folien aus den Quell‑Decks werden zu einer einzigen Präsentation kombiniert.
- Bestimmte Folien: Nur die ausgewählten Folien werden zu einer einzigen Präsentation kombiniert.
- Präsentationen desselben Formats (z. B. PPT→PPT, PPTX→PPTX) oder über verschiedene Formate hinweg (z. B. PPT→PPTX, PPTX→ODP).

{{% alert title="Hinweis" color="info" %}}

Neben Präsentationen ermöglicht Aspose.Slides auch das Zusammenführen anderer Dateien:

- [Bilder](https://products.aspose.com/slides/python-net/merger/image-to-image/), z. B. [JPG zu JPG](https://products.aspose.com/slides/python-net/merger/jpg-to-jpg/) oder [PNG zu PNG](https://products.aspose.com/slides/python-net/merger/png-to-png/).
- Dokumente, wie [PDF zu PDF](https://products.aspose.com/slides/python-net/merger/pdf-to-pdf/) oder [HTML zu HTML](https://products.aspose.com/slides/python-net/merger/html-to-html/).
- Zwei verschiedene Dateitypen, wie [Bild zu PDF](https://products.aspose.com/slides/python-net/merger/image-to-pdf/), [JPG zu PDF](https://products.aspose.com/slides/python-net/merger/jpg-to-pdf/), oder [TIFF zu PDF](https://products.aspose.com/slides/python-net/merger/tiff-to-pdf/).

{{% /alert %}}

### **Zusammenführungsoptionen**

Sie können steuern, ob:
- Jede Folie in der Ausgabepäsentation ihren ursprünglichen Stil beibehält, oder
- Ein einziger Stil auf alle Folien in der Ausgabepäsentation angewendet wird.

Um Präsentationen zusammenzuführen, stellt Aspose.Slides die [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/)‑Methoden in der Klasse [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) bereit. Diese Methodenüberladungen definieren, wie das Zusammenführen durchgeführt wird. Jedes [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Objekt stellt eine [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/)‑Sammlung bereit, sodass Sie `add_clone` auf der Folien‑Sammlung der Zielpräsentation aufrufen.

Die Methode `add_clone` gibt ein `Slide` zurück – eine Kopie der Quellfolie. Folien in der Ausgabepäsentation sind Kopien der Originale, sodass Sie die resultierenden Folien (z. B. Stil, Formatierung oder Layout) ändern können, ohne die Quellpräsentationen zu beeinflussen.

## **Präsentationen zusammenführen**

Aspose.Slides bietet die Methode [add_clone(ISlide)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide) an, mit der Sie Folien kombinieren können und dabei deren Layouts und Stile beibehalten (unter Verwendung der Standardparameter).

Das folgende Python‑Beispiel zeigt, wie Sie Präsentationen zusammenführen:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide)
        presentation1.save("combined.pptx", slides.export.SaveFormat.PPTX)
```

## **Präsentationen mit einem Folienmaster zusammenführen**

Aspose.Slides bietet die Methode [add_clone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide-asposeslidesimasterslide-bool) an, mit der Sie Folien zusammenführen können, indem Sie einen Folienmaster aus einer Vorlage anwenden. Auf diese Weise können Sie bei Bedarf die Folien in der Ausgabepäsentation neu gestalten.

Das folgende Python‑Beispiel demonstriert diese Operation:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.masters[0], True)
        presentation1.save("combined_with_master.pptx", slides.export.SaveFormat.PPTX) 
```

{{% alert title="Hinweis" color="warning" %}}

Das passende Layout unter dem angegebenen Folienmaster wird automatisch ermittelt. Wenn kein geeignetes Layout gefunden werden kann und der boolesche Parameter `allow_clone_missing_layout` der Methode `add_clone` auf `True` gesetzt ist, wird stattdessen das Layout der Quellfolie verwendet. Andernfalls wird eine [PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/) ausgelöst.

{{% /alert %}}

Um ein anderes Folienlayout auf Folien in der Ausgabepäsentation anzuwenden, verwenden Sie die Methode [add_clone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide-asposeslidesilayoutslide) beim Zusammenführen.

## **Bestimmte Folien aus Präsentationen zusammenführen**

Das Zusammenführen bestimmter Folien aus mehreren Präsentationen ist nützlich, wenn Sie benutzerdefinierte Folien‑Decks erstellen. Aspose.Slides ermöglicht Ihnen, nur die benötigten Folien auszuwählen und zu importieren, wobei das ursprüngliche Format, Layout und Design der Folien erhalten bleiben.

Das folgende Python‑Beispiel erstellt eine neue Präsentation, fügt Titelfolien aus zwei anderen Präsentationen hinzu und speichert das Ergebnis in einer Datei:

```py
def get_title_slide(pres):
    for slide in pres.slides:
        if slide.layout_slide.layout_type == slides.SlideLayoutType.TITLE:
            return slide
    return None


with slides.Presentation() as presentation, \
        slides.Presentation("presentation1.pptx") as presentation1, \
        slides.Presentation("presentation2.pptx") as presentation2:
    presentation.slides.remove_at(0)

    slide1 = get_title_slide(presentation1)
    if slide1 is not None:
        presentation.slides.add_clone(slide1)

    slide2 = get_title_slide(presentation2)
    if slide2 is not None:
        presentation.slides.add_clone(slide2)

    presentation.save("combined.pptx", slides.export.SaveFormat.PPTX)
```

## **Präsentationen mit einem Folienlayout zusammenführen**

Das folgende Python‑Beispiel zeigt, wie Sie Folien aus mehreren Präsentationen zusammenführen und dabei ein bestimmtes Folienlayout anwenden, um eine einzige Ausgabepäsentation zu erzeugen:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.layout_slides[0])
        presentation1.save("combined_with_layout.pptx", slides.export.SaveFormat.PPTX) 
```

## **Präsentationen mit unterschiedlichen Foliengrößen zusammenführen**

{{% alert title="Hinweis" color="warning" %}}

Sie können Präsentationen mit unterschiedlichen Foliengrößen nicht direkt zusammenführen.

{{% /alert %}}

Um zwei Präsentationen mit unterschiedlichen Foliengrößen zu kombinieren, passen Sie zunächst die Größe einer Präsentation an, sodass deren Foliengröße der anderen entspricht.

Der folgende Beispielcode demonstriert diesen Vorgang:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    slide_size = presentation1.slide_size.size
    with slides.Presentation("presentation2.pptx") as presentation2:
        presentation2.slide_size.set_size(slide_size.width, slide_size.height, slides.SlideSizeScaleType.ENSURE_FIT)
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide)
        presentation1.save("combined_size.pptx", slides.export.SaveFormat.PPTX) 
```

## **Folien in einen Präsentationsabschnitt zusammenführen**

Das folgende Python‑Beispiel zeigt, wie Sie eine bestimmte Folie in einen Abschnitt einer Präsentation einfügen:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.sections[0])
        presentation1.save("combined_sections.pptx", slides.export.SaveFormat.PPTX) 
```

Die Folie wird am Ende des Abschnitts hinzugefügt. 

{{% alert title="Tipp" color="primary" %}}

Suchen Sie ein schnelles **kostenloses Online‑Tool**, um **PowerPoint‑Präsentationen zusammenzuführen**? Probieren Sie den [**Aspose PowerPoint Merger**](https://products.aspose.app/slides/merger).

- **PowerPoint‑Dateien einfach zusammenführen**: Kombinieren Sie mehrere **PPT, PPTX, ODP**‑Präsentationen zu einer einzigen Datei.  
- **Unterstützt verschiedene Formate**: Zusammenführen von **PPT zu PPTX**, **PPTX zu ODP** und mehr.  
- **Keine Installation erforderlich**: Läuft direkt im Browser, schnell und sicher.  

[![Merge PowerPoint Files Online](slides-merger.png)](https://products.aspose.app/slides/merger)  

Starten Sie noch heute das Zusammenführen Ihrer PowerPoint‑Dateien mit dem **kostenlosen Aspose‑Online‑Tool**!  

{{% /alert %}}

{{% alert title="Tipp" color="primary" %}}

Aspose bietet eine [KOSTENLOSE Collage‑Web‑App](https://products.aspose.app/slides/collage). Mit diesem Online‑Dienst können Sie [JPG zu JPG](https://products.aspose.app/slides/collage/jpg) oder PNG zu PNG Bilder zusammenführen, Fotogitter erstellen und vieles mehr. 

{{% /alert %}}

## **FAQ**

**Werden Sprecherkommentare beim Zusammenführen beibehalten?**

Ja. Beim Klonen von Folien übernimmt Aspose.Slides alle Folienelemente, einschließlich Notizen, Formatierungen und Animationen.

**Werden Kommentare und deren Autoren übertragen?**

Kommentare, als Teil des Folieninhalts, werden zusammen mit der Folie kopiert. Die Autorennamen bleiben als Kommentarobjekte in der resultierenden Präsentation erhalten.

**Was ist, wenn die Quellpräsentation passwortgeschützt ist?**

Sie muss [mit dem Passwort geöffnet werden](/slides/de/python-net/password-protected-presentation/) über [LoadOptions.password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/); nach dem Laden können diese Folien sicher in eine ungeschützte Zieldatei (oder ebenfalls geschützt) geklont werden.

**Wie threadsicher ist der Zusammenführungsvorgang?**

Verwenden Sie nicht dieselbe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Instanz aus mehreren Threads. Die empfohlene Regel lautet „ein Dokument – ein Thread“; verschiedene Dateien können parallel in separaten Threads verarbeitet werden.