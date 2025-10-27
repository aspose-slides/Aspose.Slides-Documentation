---
title: Effizient Präsentationen mit Python zusammenführen
linktitle: Präsentationen zusammenführen
type: docs
weight: 40
url: /de/python-net/merge-presentation/
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
description: "Müheloses Zusammenführen von PowerPoint‑ (PPT, PPTX) und OpenDocument‑ (ODP) Präsentationen mit Aspose.Slides für Python via .NET, wodurch Ihr Arbeitsablauf optimiert wird."
---

## **Optimieren Sie das Zusammenführen von Präsentationen**

Mit [Aspose.Slides for Python](https://products.aspose.com/slides/python-net/) können Sie PowerPoint‑Präsentationen nahtlos kombinieren und dabei Stile, Layouts und alle Elemente erhalten. Im Gegensatz zu anderen Tools fügt Aspose.Slides Präsentationen zusammen, ohne die Qualität zu beeinträchtigen oder Daten zu verlieren. Fügen Sie komplette Decks, ausgewählte Folien oder sogar verschiedene Dateiformate (z. B. PPT zu PPTX) zusammen.

### **Funktionen zum Zusammenführen**

- **Komplettes Präsentations‑Merge:** Alle Folien zu einer einzigen Datei zusammenstellen.
- **Selektives Folien‑Merge:** Ausgewählte Folien auswählen und kombinieren.
- **Cross‑Format‑Merge:** Präsentationen unterschiedlicher Formate integrieren und die Integrität bewahren.

## **Präsentations‑Merge**

Wenn Sie eine Präsentation in eine andere einfügen, kombinieren Sie im Wesentlichen deren Folien zu einer einzigen Präsentation, um eine Datei zu erzeugen. Die meisten Präsentationsprogramme – wie PowerPoint oder OpenOffice – bieten keine Funktionen, die ein solches Zusammenführen ermöglichen.

Doch [Aspose.Slides for Python](https://products.aspose.com/slides/python-net/) erlaubt das Zusammenführen von Präsentationen auf verschiedene Arten. Sie können Präsentationen mit allen Formen, Stilen, Texten, Formatierungen, Kommentaren und Animationen zusammenführen, ohne Qualitäts‑ oder Datenverlust.

**Siehe auch**

[PowerPoint‑Folien in Python klonen](/slides/de/python-net/clone-slides/)

### **Was kann zusammengeführt werden**

Mit Aspose.Slides können Sie Folgendes zusammenführen:

- Ganze Präsentationen: Alle Folien der Quell‑Decks werden zu einer einzigen Präsentation kombiniert.
- Bestimmte Folien: Nur die ausgewählten Folien werden zu einer einzigen Präsentation kombiniert.
- Präsentationen desselben Formats (z. B. PPT→PPT, PPTX→PPTX) oder über verschiedene Formate hinweg (z. B. PPT→PPTX, PPTX→ODP).

{{% alert title="Hinweis" color="info" %}}

Neben Präsentationen ermöglicht Aspose.Slides auch das Zusammenführen anderer Dateitypen:

- [Bilder](https://products.aspose.com/slides/python-net/merger/image-to-image/), zum Beispiel [JPG zu JPG](https://products.aspose.com/slides/python-net/merger/jpg-to-jpg/) oder [PNG zu PNG](https://products.aspose.com/slides/python-net/merger/png-to-png/).
- Dokumente, etwa [PDF zu PDF](https://products.aspose.com/slides/python-net/merger/pdf-to-pdf/) oder [HTML zu HTML](https://products.aspose.com/slides/python-net/merger/html-to-html/).
- Zwei unterschiedliche Dateitypen, etwa [Bild zu PDF](https://products.aspose.com/slides/python-net/merger/image-to-pdf/), [JPG zu PDF](https://products.aspose.com/slides/python-net/merger/jpg-to-pdf/) oder [TIFF zu PDF](https://products.aspose.com/slides/python-net/merger/tiff-to-pdf/).

{{% /alert %}}

### **Merge‑Optionen**

Sie können festlegen, ob:
- Jede Folie in der Ausgabepäsentation ihren ursprünglichen Stil behält, oder
- Ein einheitlicher Stil auf alle Folien der Ausgabepäsentation angewendet wird.

Zum Zusammenführen von Präsentationen stellt Aspose.Slides die Methoden **add_clone** auf der Klasse [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) bereit. Diese Methoden‑Überladungen bestimmen, wie das Merge durchgeführt wird. Jedes [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Objekt besitzt eine **slides**‑Sammlung, sodass Sie `add_clone` auf der Folien‑Collection der Ziel‑Präsentation aufrufen.

Die Methode `add_clone` gibt ein **Slide**‑Objekt zurück – eine Kopie der Quellfolie. Folien in der Ausgabepäsentation sind Kopien der Originale, sodass Sie die resultierenden Folien (z. B. Stil, Formatierung oder Layout) ändern können, ohne die Quellpräsentationen zu beeinflussen.

## **Präsentationen zusammenführen** 

Aspose.Slides stellt die Methode [add_clone(ISlide)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide) bereit, die Folien zusammenführt und gleichzeitig deren Layouts und Stile beibehält (unter Verwendung der Standardparameter).

Das folgende Python‑Beispiel demonstriert das Zusammenführen von Präsentationen:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide)
        presentation1.save("combined.pptx", slides.export.SaveFormat.PPTX)
```

## **Präsentationen mit einem Folienmaster zusammenführen**

Aspose.Slides stellt die Methode [add_clone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide-asposeslidesimasterslide-bool) bereit, die Folien zusammenführt und dabei einen Folienmaster aus einer Vorlage anwendet. Auf diese Weise können Sie bei Bedarf die Folien in der Ausgabepäsentation neu stylen.

Das folgende Python‑Beispiel zeigt diesen Vorgang:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.masters[0], True)
        presentation1.save("combined_with_master.pptx", slides.export.SaveFormat.PPTX) 
```

{{% alert title="Hinweis" color="warning" %}}

Das passende Layout unter dem angegebenen Folienmaster wird automatisch bestimmt. Wird kein geeignetes Layout gefunden und ist der boolesche Parameter `allow_clone_missing_layout` der Methode `add_clone` auf `True` gesetzt, wird stattdessen das Layout der Quellfolie verwendet. Andernfalls wird eine [PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/) ausgelöst.

{{% /alert %}}

Um ein anderes Folienlayout auf die Folien der Ausgabepäsentation anzuwenden, verwenden Sie die Methode [add_clone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide-asposeslidesilayoutslide) beim Merge.

## **Bestimmte Folien aus Präsentationen zusammenführen**

Das gezielte Zusammenführen einzelner Folien aus mehreren Präsentationen ist nützlich, wenn Sie benutzerdefinierte Foliendecks erstellen. Aspose.Slides ermöglicht es, nur die benötigten Folien auszuwählen und zu importieren, wobei Formatierung, Layout und Design der Originalfolien erhalten bleiben.

Das folgende Python‑Beispiel erstellt eine neue Präsentation, fügt Titelfolien aus zwei anderen Präsentationen ein und speichert das Ergebnis:

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

Präsentationen mit unterschiedlichen Foliengrößen können nicht direkt zusammengeführt werden.

{{% /alert %}}

Um zwei Präsentationen mit verschiedenen Foliengrößen zu kombinieren, passen Sie zunächst die Größe einer Präsentation an die der anderen an.

Das folgende Beispiel demonstriert diesen Vorgang:

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

Das folgende Python‑Beispiel zeigt, wie Sie eine bestimmte Folie in einen Abschnitt einer Präsentation einfügen:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.sections[0])
        presentation1.save("combined_sections.pptx", slides.export.SaveFormat.PPTX) 
```

Die Folie wird am Ende des Abschnitts eingefügt. 

{{% alert title="Tipp" color="primary" %}}

Suchen Sie ein schnelles **kostenloses Online‑Tool**, um **PowerPoint‑Präsentationen** zusammenzuführen? Probieren Sie den [**Aspose PowerPoint Merger**](https://products.aspose.app/slides/merger).

- **PowerPoint‑Dateien einfach zusammenführen**: Kombinieren Sie mehrere **PPT, PPTX, ODP**‑Präsentationen zu einer einzigen Datei.  
- **Unterstützt verschiedene Formate**: Merge **PPT zu PPTX**, **PPTX zu ODP** und mehr.  
- **Keine Installation nötig**: Läuft direkt im Browser, schnell und sicher.  

[![Merge PowerPoint Files Online](slides-merger.png)](https://products.aspose.app/slides/merger)  

Starten Sie noch heute das Zusammenführen Ihrer PowerPoint‑Dateien mit dem **kostenlosen Aspose‑Online‑Tool**!  

{{% /alert %}}

{{% alert title="Tipp" color="primary" %}}

Aspose bietet eine **KOSTENLOSE Collage‑Web‑App** an ([https://products.aspose.app/slides/collage](https://products.aspose.app/slides/collage)). Mit diesem Online‑Dienst können Sie [JPG zu JPG](https://products.aspose.app/slides/collage/jpg) oder PNG zu PNG‑Bilder zusammenführen, Fotogitter erstellen ([https://products.aspose.app/slides/collage/photo-grid](https://products.aspose.app/slides/collage/photo-grid)) und vieles mehr. 

{{% /alert %}}

## **FAQ**

**Werden Sprecher‑Notizen beim Zusammenführen erhalten?**

Ja. Beim Klonen der Folien übernimmt Aspose.Slides alle Folienelemente, einschließlich Notizen, Formatierung und Animationen.

**Werden Kommentare und deren Autoren übertragen?**

Kommentare, die Teil des Folieninhalts sind, werden mit der Folie kopiert. Die Autor‑Labels bleiben als Kommentarobjekte in der resultierenden Präsentation erhalten.

**Was passiert, wenn die Quellpräsentation passwortgeschützt ist?**

Sie muss über [LoadOptions.password](/slides/de/python-net/password-protected-presentation/) mit dem Passwort geöffnet werden; nach dem Laden können die Folien sicher in eine ungeschützte Ziel‑Datei (oder ebenfalls geschützt) geklont werden.

**Wie thread‑sicher ist der Merge‑Vorgang?**

Verwenden Sie nicht dieselbe [Presentation]‑Instanz aus mehreren Threads. Die empfohlene Regel lautet „ein Dokument – ein Thread“; verschiedene Dateien können parallel in separaten Threads verarbeitet werden.