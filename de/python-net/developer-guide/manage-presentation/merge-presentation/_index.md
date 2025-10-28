---
title: Präsentationen effizient mit Python zusammenführen
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
description: "Müheloses Zusammenführen von PowerPoint (PPT, PPTX) und OpenDocument (ODP) Präsentationen mit Aspose.Slides für Python über .NET, wodurch Ihr Arbeitsablauf optimiert wird."
---

## **Optimieren Sie das Zusammenführen von Präsentationen**

Mit [Aspose.Slides for Python](https://products.aspose.com/slides/python-net/) können Sie PowerPoint‑Präsentationen nahtlos kombinieren und dabei Stile, Layouts und alle Elemente beibehalten. Im Gegensatz zu anderen Tools führt Aspose.Slides Präsentationen zusammen, ohne die Qualität zu beeinträchtigen oder Daten zu verlieren. Fügen Sie komplette Decks, bestimmte Folien oder sogar unterschiedliche Dateiformate (z. B. PPT zu PPTX) zusammen.

### **Zusammenführungs‑Funktionen**

- **Vollständiges Präsentations‑Merge:** Alle Folien zu einer einzigen Datei zusammenstellen.
- **Gezieltes Folien‑Merge:** Ausgewählte Folien kombinieren.
- **Cross‑Format‑Merge:** Präsentationen verschiedener Formate integrieren und die Integrität wahren.

## **Präsentations‑Merge**

Wenn Sie eine Präsentation in eine andere einfügen, kombinieren Sie deren Folien zu einer einzigen Präsentation, aus der dann eine Datei entsteht. Die meisten Präsentationsprogramme – wie PowerPoint oder OpenOffice – bieten keine Funktion, mit der Sie Präsentationen auf diese Weise zusammenführen können.

Doch [Aspose.Slides for Python](https://products.aspose.com/slides/python-net/) ermöglicht das Zusammenführen von Präsentationen auf verschiedene Arten. Sie können Präsentationen mit allen Formen, Stilen, Texten, Formatierungen, Kommentaren und Animationen zusammenführen, ohne Qualitäts‑ oder Datenverlust.

**Siehe auch**

[PowerPoint‑Folien in Python klonen](/slides/de/python-net/clone-slides/)

### **Was kann zusammengeführt werden**

Mit Aspose.Slides können Sie Folgendes zusammenführen:

- Komplett‑Präsentationen: Alle Folien aus den Quell‑Decks werden zu einer einzigen Präsentation kombiniert.
- Einzelne Folien: Nur die ausgewählten Folien werden zu einer einzigen Präsentation kombiniert.
- Präsentationen im selben Format (z. B. PPT→PPT, PPTX→PPTX) oder über verschiedene Formate hinweg (z. B. PPT→PPTX, PPTX→ODP).

{{% alert title="Hinweis" color="info" %}}

Neben Präsentationen können Sie mit Aspose.Slides auch andere Dateien zusammenführen:

- [Bilder](https://products.aspose.com/slides/python-net/merger/image-to-image/), z. B. [JPG zu JPG](https://products.aspose.com/slides/python-net/merger/jpg-to-jpg/) oder [PNG zu PNG](https://products.aspose.com/slides/python-net/merger/png-to-png/).
- Dokumente, z. B. [PDF zu PDF](https://products.aspose.com/slides/python-net/merger/pdf-to-pdf/) oder [HTML zu HTML](https://products.aspose.com/slides/python-net/merger/html-to-html/).
- Zwei unterschiedliche Dateitypen, z. B. [Bild zu PDF](https://products.aspose.com/slides/python-net/merger/image-to-pdf/), [JPG zu PDF](https://products.aspose.com/slides/python-net/merger/jpg-to-pdf/) oder [TIFF zu PDF](https://products.aspose.com/slides/python-net/merger/tiff-to-pdf/).

{{% /alert %}}

### **Merge‑Optionen**

Sie können festlegen, ob:
- Jede Folie in der Ausgabedatei ihren ursprünglichen Stil behält, oder
- Ein einheitlicher Stil auf alle Folien der Ausgabedatei angewendet wird.

Um Präsentationen zusammenzuführen, stellt Aspose.Slides die [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/)-Methoden der Klasse [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) bereit. Diese Method‑Overloads bestimmen, wie das Merge durchgeführt wird. Jedes [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Objekt enthält eine [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/)-Sammlung, sodass Sie `add_clone` auf der Slide‑Collection der Ziel‑Präsentation aufrufen.

Die `add_clone`‑Methode gibt ein `Slide`‑Objekt zurück – eine Kopie der Quellfolie. Die Folien in der Ausgabedatei sind Kopien der Originale, sodass Sie die resultierenden Folien (z. B. Stil, Formatierung oder Layout) ändern können, ohne die Quellpräsentationen zu beeinflussen.

## **Präsentationen zusammenführen** 

Aspose.Slides bietet die Methode [add_clone(ISlide)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide), die das Kombinieren von Folien bei gleichzeitiger Beibehaltung von Layouts und Stilen (mittels Standard‑Parameter) ermöglicht.

Das folgende Python‑Beispiel zeigt, wie Präsentationen zusammengeführt werden:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide)
        presentation1.save("combined.pptx", slides.export.SaveFormat.PPTX)
```

## **Präsentationen mit einem Folien‑Master zusammenführen**

Aspose.Slides stellt die Methode [add_clone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide-asposeslidesimasterslide-bool) bereit, mit der Sie Folien zusammenführen und dabei einen Folien‑Master aus einer Vorlage anwenden. Auf diese Weise können Sie bei Bedarf die Folien in der Ausgabedatei neu stilisieren.

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

Das passende Layout unter dem angegebenen Folien‑Master wird automatisch bestimmt. Wenn kein geeignetes Layout gefunden wird und der boolesche Parameter `allow_clone_missing_layout` der `add_clone`‑Methode auf `True` gesetzt ist, wird stattdessen das Layout der Quellfolie verwendet. Andernfalls wird eine [PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/) ausgelöst.

{{% /alert %}}

Um ein anderes Folien‑Layout für die Folien in der Ausgabedatei zu verwenden, nutzen Sie die Methode [add_clone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide-asposeslidesilayoutslide) beim Zusammenführen.

## **Bestimmte Folien aus Präsentationen zusammenführen**

Das Zusammenführen ausgewählter Folien aus mehreren Präsentationen ist praktisch, wenn Sie individuelle Folien‑Decks erstellen. Aspose.Slides ermöglicht das Auswählen und Importieren nur der benötigten Folien, wobei die ursprüngliche Formatierung, das Layout und das Design erhalten bleiben.

Das folgende Python‑Beispiel erstellt eine neue Präsentation, fügt Titelfolien aus zwei anderen Präsentationen hinzu und speichert das Ergebnis:

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

## **Präsentationen mit einem Folien‑Layout zusammenführen**

Das folgende Python‑Beispiel zeigt, wie Sie Folien aus mehreren Präsentationen zusammenführen und dabei ein bestimmtes Folien‑Layout anwenden, um eine einheitliche Ausgabedatei zu erzeugen:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.layout_slides[0])
        presentation1.save("combined_with_layout.pptx", slides.export.SaveFormat.PPTX) 
```

## **Präsentationen mit unterschiedlichen Folien‑Größen zusammenführen**

{{% alert title="Hinweis" color="warning" %}}

Präsentationen mit unterschiedlichen Folien‑Größen können nicht direkt zusammengeführt werden.

{{% /alert %}}

Um zwei Präsentationen mit verschiedenen Folien‑Größen zu kombinieren, passen Sie zunächst eine Präsentation so an, dass deren Folien‑Größe der anderen entspricht.

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

## **Folien in einen Präsentations‑Abschnitt einfügen**

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

Suchen Sie ein schnelles und **kostenloses Online‑Tool** zum **Zusammenführen von PowerPoint‑Präsentationen**? Probieren Sie den [**Aspose PowerPoint Merger**](https://products.aspose.app/slides/merger).

- **PowerPoint‑Dateien einfach zusammenführen**: Kombinieren Sie mehrere **PPT, PPTX, ODP**‑Präsentationen zu einer einzigen Datei.  
- **Unterstützt verschiedene Formate**: Merge **PPT zu PPTX**, **PPTX zu ODP** und mehr.  
- **Keine Installation erforderlich**: Läuft direkt im Browser, schnell und sicher.  

[![Merge PowerPoint Files Online](slides-merger.png)](https://products.aspose.app/slides/merger)  

Starten Sie noch heute das Zusammenführen Ihrer PowerPoint‑Dateien mit dem **Aspose kostenlosen Online‑Tool**!  

{{% /alert %}}

{{% alert title="Tipp" color="primary" %}}

Aspose stellt eine [KOSTENLOSE Collage‑Web‑App](https://products.aspose.app/slides/collage) bereit. Mit diesem Online‑Dienst können Sie [JPG zu JPG](https://products.aspose.app/slides/collage/jpg) oder PNG‑zu‑PNG‑Bilder zusammenführen, Fotogitter erstellen und vieles mehr. 

{{% /alert %}}

## **FAQ**

**Werden Sprechernotizen beim Merge erhalten?**

Ja. Beim Klonen von Folien übernimmt Aspose.Slides alle Folienelemente, einschließlich Notizen, Formatierung und Animationen.

**Werden Kommentare und deren Autoren übernommen?**

Kommentare, als Teil des Folieninhalts, werden mit der Folie kopiert. Die Autoren‑Labels bleiben als Kommentarobjekte in der resultierenden Präsentation erhalten.

**Was passiert, wenn die Quellpräsentation passwortgeschützt ist?**

Sie muss über [LoadOptions.password](/slides/de/python-net/password-protected-presentation/) mit dem Passwort geöffnet werden; nach dem Laden können die Folien sicher in eine ungeschützte Zieldatei (oder ebenfalls geschützte) geklont werden.

**Wie thread‑sicher ist der Merge‑Vorgang?**

Verwenden Sie nicht dieselbe [Presentation](/slides/de/python-net/multithreading/)‑Instanz aus mehreren Threads. Die Empfehlung lautet „ein Dokument – ein Thread“; unterschiedliche Dateien können parallel in separaten Threads verarbeitet werden.