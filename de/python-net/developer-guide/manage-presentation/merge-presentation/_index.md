---
title: Effizient Präsentationen mit Python zusammenführen
linktitle: Präsentationen zusammenführen
type: docs
weight: 40
url: /de/python-net/merge-presentation/
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
- Python
- Aspose.Slides
description: "Müheloses Zusammenführen von PowerPoint‑ (PPT, PPTX) und OpenDocument‑ (ODP) Präsentationen mit Aspose.Slides für Python via .NET, zur Optimierung Ihres Workflows."
---

## **Optimieren Sie das Zusammenführen Ihrer Präsentationen**

Mit [Aspose.Slides for Python](https://products.aspose.com/slides/python-net/) können Sie PowerPoint‑Präsentationen nahtlos kombinieren und dabei Stile, Layouts und alle Elemente erhalten. Im Gegensatz zu anderen Werkzeugen verbindet Aspose.Slides Präsentationen, ohne die Qualität zu beeinträchtigen oder Daten zu verlieren. Fügen Sie komplette Decks, einzelne Folien oder sogar unterschiedliche Dateiformate (z. B. PPT zu PPTX) zusammen.

### **Zusammenführungsfunktionen**

- **Vollständige Präsentations‑Zusammenführung:** Alle Folien zu einer einzigen Datei zusammenstellen.
- **Spezifische Folien‑Zusammenführung:** Ausgewählte Folien auswählen und kombinieren.
- **Formatübergreifende Zusammenführung:** Präsentationen verschiedener Formate integrieren und die Integrität wahren.

## **Präsentations‑Zusammenführung**

Wenn Sie eine Präsentation in eine andere einfügen, kombinieren Sie deren Folien zu einer einzigen Präsentation, aus der dann eine Datei entsteht. Die meisten Präsentationsprogramme – wie PowerPoint oder OpenOffice – bieten keine Funktionen, mit denen Sie Präsentationen auf diese Weise zusammenführen können.

Doch [Aspose.Slides for Python](https://products.aspose.com/slides/python-net/) ermöglicht das Zusammenführen von Präsentationen auf verschiedene Arten. Sie können Präsentationen mit allen Formen, Stilen, Text, Formatierungen, Kommentaren und Animationen zusammenführen, ohne Qualitäts‑ oder Datenverlust.

**Siehe auch**

[PowerPoint‑Folien in Python duplizieren](/slides/de/python-net/clone-slides/)

### **Was kann zusammengeführt werden**

Mit Aspose.Slides können Sie Folgendes zusammenführen:

- Ganze Präsentationen: Alle Folien aus den Quell‑Decks werden zu einer einzigen Präsentation kombiniert.
- Bestimmte Folien: Nur die ausgewählten Folien werden zu einer einzigen Präsentation kombiniert.
- Präsentationen im selben Format (z. B. PPT→PPT, PPTX→PPTX) oder über verschiedene Formate hinweg (z. B. PPT→PPTX, PPTX→ODP).

{{% alert title="Hinweis" color="info" %}}

Neben Präsentationen ermöglicht Aspose.Slides auch das Zusammenführen anderer Dateien:

- [Bilder](https://products.aspose.com/slides/python-net/merger/image-to-image/), z. B. [JPG zu JPG](https://products.aspose.com/slides/python-net/merger/jpg-to-jpg/) oder [PNG zu PNG](https://products.aspose.com/slides/python-net/merger/png-to-png/).
- Dokumente, z. B. [PDF zu PDF](https://products.aspose.com/slides/python-net/merger/pdf-to-pdf/) oder [HTML zu HTML](https://products.aspose.com/slides/python-net/merger/html-to-html/).
- Zwei unterschiedliche Dateitypen, z. B. [Bild zu PDF](https://products.aspose.com/slides/python-net/merger/image-to-pdf/), [JPG zu PDF](https://products.aspose.com/slides/python-net/merger/jpg-to-pdf/) oder [TIFF zu PDF](https://products.aspose.com/slides/python-net/merger/tiff-to-pdf/).

{{% /alert %}}

### **Zusammenführungsoptionen**

Sie können steuern, ob:
- Jede Folie in der Ausgabepresentation ihren ursprünglichen Stil beibehält, oder
- Ein einheitlicher Stil auf alle Folien in der Ausgabepresentation angewendet wird.

Zum Zusammenführen von Präsentationen stellt Aspose.Slides die Methode [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) der Klasse [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) bereit. Diese Methoden‑Überladungen definieren, wie die Zusammenführung durchgeführt wird. Jedes [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Objekt besitzt eine [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/)-Sammlung, sodass Sie `add_clone` auf der Folien‑Sammlung der Ziel‑Presentation aufrufen.

Die Methode `add_clone` gibt ein `Slide`‑Objekt zurück – eine Kopie der Quellfolie. Folien in der Ausgabepresentation sind Kopien der Originale, sodass Sie die resultierenden Folien (z. B. Stile, Formatierungen oder Layouts) ändern können, ohne die Quellpräsentationen zu beeinflussen.

## **Präsentationen zusammenführen** 

Aspose.Slides stellt die Methode [add_clone(ISlide)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide) bereit, die es ermöglicht, Folien zu kombinieren und dabei deren Layouts und Stile beizubehalten (unter Verwendung der Standardparameter).

Das folgende Python‑Beispiel zeigt, wie Präsentationen zusammengeführt werden:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide)
        presentation1.save("combined.pptx", slides.export.SaveFormat.PPTX)
```

## **Präsentationen mit einem Folienmaster zusammenführen**

Aspose.Slides bietet die Methode [add_clone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide-asposeslidesimasterslide-bool) an, mit der Sie Folien zusammenführen können, während ein Folienmaster aus einer Vorlage angewendet wird. Auf diese Weise können Sie bei Bedarf die Folien in der Ausgabepresentation neu stylen.

Das folgende Python‑Beispiel demonstriert diesen Vorgang:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.masters[0], True)
        presentation1.save("combined_with_master.pptx", slides.export.SaveFormat.PPTX) 
```

{{% alert title="Hinweis" color="warning" %}}

Das passende Layout unter dem angegebenen Folienmaster wird automatisch ermittelt. Wird kein geeignetes Layout gefunden und der boolesche Parameter `allow_clone_missing_layout` der Methode `add_clone` ist auf `True` gesetzt, wird das Layout der Quellfolie verwendet. Andernfalls wird eine [PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/) ausgelöst.

{{% /alert %}}

Um ein anderes Folienlayout für die Folien in der Ausgabepresentation zu verwenden, nutzen Sie die Methode [add_clone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide-asposeslidesilayoutslide) beim Zusammenführen.

## **Bestimmte Folien aus Präsentationen zusammenführen**

Das Zusammenführen bestimmter Folien aus mehreren Präsentationen ist nützlich, wenn Sie individuelle Foliensets erstellen. Aspose.Slides ermöglicht Ihnen, nur die benötigten Folien auszuwählen und zu importieren, während Formatierung, Layout und Design der Originalfolien erhalten bleiben.

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

Das folgende Python‑Beispiel zeigt, wie Folien aus mehreren Präsentationen zusammengeführt werden, wobei ein bestimmtes Folienlayout angewendet wird, um eine einzige Ausgabepresentation zu erzeugen:

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

Präsentationen mit unterschiedlichen Foliengrößen können nicht direkt zusammengeführt werden.

{{% /alert %}}

Um zwei Präsentationen mit unterschiedlichen Foliengrößen zusammenzuführen, passen Sie zuerst eine Präsentation an, sodass ihre Foliengröße der anderen entspricht.

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

## **Folien in einen Präsentationsabschnitt einfügen**

Das folgende Python‑Beispiel zeigt, wie eine bestimmte Folie in einen Abschnitt einer Präsentation eingefügt wird:

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

Suchen Sie ein schnelles **kostenloses Online‑Tool**, um **PowerPoint‑Präsentationen** zusammenzuführen? Probieren Sie den **[Aspose PowerPoint Merger](https://products.aspose.app/slides/merger)**.

- **PowerPoint‑Dateien einfach zusammenführen**: Kombinieren Sie mehrere **PPT, PPTX, ODP**‑Präsentationen zu einer einzigen Datei.  
- **Unterstützt verschiedene Formate**: Zusammenführen von **PPT zu PPTX**, **PPTX zu ODP** und mehr.  
- **Keine Installation nötig**: Läuft direkt im Browser, schnell und sicher.  

[![Merge PowerPoint Files Online](slides-merger.png)](https://products.aspose.app/slides/merger)  

Starten Sie noch heute das Zusammenführen Ihrer PowerPoint‑Dateien mit dem **Aspose‑Kostenlos‑Online‑Tool**!  

{{% /alert %}}

{{% alert title="Tipp" color="primary" %}}

Aspose bietet eine **[KOSTENLOSE Collage‑Web‑App](https://products.aspose.app/slides/collage)**. Mit diesem Online‑Dienst können Sie z. B. [JPG zu JPG](https://products.aspose.app/slides/collage/jpg) oder PNG‑zu‑PNG‑Bilder zusammenführen, Fotogitter erstellen und vieles mehr. 

{{% /alert %}}

## **FAQ**

**Werden Sprecher‑Notizen beim Zusammenführen erhalten?**

Ja. Beim Klonen von Folien übernimmt Aspose.Slides alle Folienelemente, einschließlich Notizen, Formatierungen und Animationen.

**Werden Kommentare und deren Autoren übertragen?**

Kommentare, als Bestandteil des Folieninhalts, werden zusammen mit der Folie kopiert. Die Autor‑Labels bleiben als Kommentar‑Objekte in der resultierenden Präsentation erhalten.

**Wie verfahren Sie, wenn die Quellpräsentation passwortgeschützt ist?**

Sie muss [mit dem Passwort geöffnet werden](/slides/de/python-net/password-protected-presentation/) über [LoadOptions.password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/); nach dem Laden können diese Folien sicher in eine ungeschützte Zieldatei (oder ebenfalls in eine geschützte) geklont werden.

**Wie thread‑sicher ist der Zusammenführungs‑Vorgang?**

Verwenden Sie nicht dieselbe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Instanz aus mehreren Threads (/slides/de/python-net/multithreading/). Die empfohlene Regel lautet „ein Dokument – ein Thread“; verschiedene Dateien können parallel in separaten Threads verarbeitet werden.