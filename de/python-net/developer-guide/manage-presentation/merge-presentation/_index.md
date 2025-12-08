---
title: Effizientes Zusammenführen von Präsentationen mit Python
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
description: "PowerPoint (PPT, PPTX) und OpenDocument (ODP)-Präsentationen mühelos mit Aspose.Slides für Python via .NET zusammenführen und Ihren Arbeitsablauf optimieren."
---

## **Optimieren Sie das Zusammenführen von Präsentationen**

Mit [Aspose.Slides for Python](https://products.aspose.com/slides/python-net/) können Sie PowerPoint‑Präsentationen nahtlos kombinieren und dabei Stile, Layouts und alle Elemente beibehalten. Im Gegensatz zu anderen Tools führt Aspose.Slides Präsentationen zusammen, ohne die Qualität zu beeinträchtigen oder Daten zu verlieren. Kombinieren Sie ganze Decks, bestimmte Folien oder sogar verschiedene Dateiformate (z. B. PPT zu PPTX).

### **Zusammenführungs‑Features**

- **Vollständiges Präsentations‑Merge:** Alle Folien zu einer einzigen Datei zusammenstellen.  
- **Spezifisches Folien‑Merge:** Ausgewählte Folien wählen und kombinieren.  
- **Cross‑Format‑Merge:** Präsentationen unterschiedlicher Formate integrieren und die Integrität wahren.

## **Präsentations‑Merge**

Wenn Sie eine Präsentation in eine andere einfügen, kombinieren Sie deren Folien zu einer einzigen Präsentation, um eine Datei zu erzeugen. Die meisten Präsentationsprogramme – wie PowerPoint oder OpenOffice – bieten keine Funktionen, mit denen Sie Präsentationen auf diese Weise zusammenführen können.

[Aspose.Slides for Python](https://products.aspose.com/slides/python-net/) ermöglicht jedoch das Zusammenführen von Präsentationen auf verschiedene Arten. Sie können Präsentationen mit sämtlichen Formen, Stilen, Texten, Formatierungen, Kommentaren und Animationen zusammenführen, ohne Qualitäts‑ oder Datenverlust.

**Siehe auch**

[Clone PowerPoint Slides in Python](/slides/de/python-net/clone-slides/)

### **Was kann zusammengeführt werden**

Mit Aspose.Slides können Sie Folgendes zusammenführen:

- Ganze Präsentationen: Alle Folien aus den Quell‑Decks werden zu einer einzigen Präsentation kombiniert.  
- Bestimmte Folien: Nur die ausgewählten Folien werden zu einer einzigen Präsentation kombiniert.  
- Präsentationen desselben Formats (z. B. PPT→PPT, PPTX→PPTX) oder verschiedener Formate (z. B. PPT→PPTX, PPTX→ODP).

{{% alert title="Hinweis" color="info" %}}

Neben Präsentationen ermöglicht Aspose.Slides auch das Zusammenführen anderer Dateien:

- [Bilder](https://products.aspose.com/slides/python-net/merger/image-to-image/), z. B. [JPG zu JPG](https://products.aspose.com/slides/python-net/merger/jpg-to-jpg/) oder [PNG zu PNG](https://products.aspose.com/slides/python-net/merger/png-to-png/).  
- Dokumente, z. B. [PDF zu PDF](https://products.aspose.com/slides/python-net/merger/pdf-to-pdf/) oder [HTML zu HTML](https://products.aspose.com/slides/python-net/merger/html-to-html/).  
- Zwei unterschiedliche Dateitypen, z. B. [Bild zu PDF](https://products.aspose.com/slides/python-net/merger/image-to-pdf/), [JPG zu PDF](https://products.aspose.com/slides/python-net/merger/jpg-to-pdf/) oder [TIFF zu PDF](https://products.aspose.com/slides/python-net/merger/tiff-to-pdf/).

{{% /alert %}}

### **Merge‑Optionen**

Sie können steuern, ob:  
- Jede Folie in der Ausgabepäsentation ihren ursprünglichen Stil beibehält, oder  
- Ein einheitlicher Stil auf alle Folien in der Ausgabepäsentation angewendet wird.

Um Präsentationen zusammenzuführen, stellt Aspose.Slides die [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/)‑Methoden der [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/)-Klasse bereit. Diese Methoden‑Überladungen definieren, wie das Merge durchgeführt wird. Jedes [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Objekt besitzt eine [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/)-Sammlung, sodass Sie `add_clone` auf der Folien‑Sammlung der Zielpräsentation aufrufen.

Die `add_clone`‑Methode gibt ein `Slide`‑Objekt zurück – eine Kopie der Quellfolie. Folien in der Ausgabepäsentation sind Kopien der Originale, sodass Sie die resultierenden Folien (z. B. Stil, Formatierung oder Layout) ändern können, ohne die Quellpräsentationen zu beeinflussen.

## **Präsentationen zusammenführen** 

Aspose.Slides stellt die [add_clone(ISlide)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide)-Methode bereit, mit der Sie Folien zusammenführen und dabei Layouts und Stile beibehalten (unter Verwendung der Standardparameter).

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

Aspose.Slides bietet die [add_clone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide-asposeslidesimasterslide-bool)-Methode, mit der Sie Folien zusammenführen und dabei einen Folienmaster aus einer Vorlage anwenden. So können Sie bei Bedarf die Folien in der Ausgabepäsentation neu stylen.

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

Das passende Layout unter dem angegebenen Folienmaster wird automatisch ermittelt. Wenn kein geeignetes Layout gefunden wird und der boolesche Parameter `allow_clone_missing_layout` der `add_clone`‑Methode auf `True` gesetzt ist, wird stattdessen das Layout der Quellfolie verwendet. Andernfalls wird eine [PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/) ausgelöst.

{{% /alert %}}

Um in der Ausgabepäsentation ein anderes Folienlayout zu verwenden, nutzen Sie die [add_clone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide-asposeslidesilayoutslide)-Methode beim Merge.

## **Bestimmte Folien aus Präsentationen zusammenführen**

Das Zusammenführen bestimmter Folien aus mehreren Präsentationen ist nützlich, um benutzerdefinierte Foliendecks zu erstellen. Aspose.Slides ermöglicht es Ihnen, nur die benötigten Folien auszuwählen und zu importieren, wobei das ursprüngliche Format, Layout und Design erhalten bleiben.

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

Das folgende Python‑Beispiel zeigt, wie Sie Folien aus mehreren Präsentationen zusammenführen und dabei ein bestimmtes Folienlayout anwenden, um eine einzelne Ausgabepäsentation zu erzeugen:
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

Um zwei Präsentationen mit unterschiedlichen Foliengrößen zu merge‑en, passen Sie zunächst die Größe einer Präsentation so an, dass ihre Foliengröße der der anderen entspricht.

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


## **Folien in einen Präsentations‑Abschnitt zusammenführen**

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

Suchen Sie ein schnelles **kostenloses Online‑Tool**, um **PowerPoint‑Präsentationen** zu **mergen**? Probieren Sie den [**Aspose PowerPoint Merger**](https://products.aspose.app/slides/merger) aus.

- **PowerPoint‑Dateien einfach zusammenführen**: Kombinieren Sie mehrere **PPT, PPTX, ODP**‑Präsentationen zu einer einzigen Datei.  
- **Unterstützt verschiedene Formate**: Merge **PPT zu PPTX**, **PPTX zu ODP** und mehr.  
- **Keine Installation erforderlich**: Läuft direkt im Browser, schnell und sicher.  

[![Merge PowerPoint Files Online](slides-merger.png)](https://products.aspose.app/slides/merger)  

Starten Sie noch heute das Zusammenführen Ihrer PowerPoint‑Dateien mit dem **kostenlosen Aspose‑Online‑Tool**!  

{{% /alert %}}

{{% alert title="Tipp" color="primary" %}}

Aspose bietet eine [KOSTENLOSE Collage‑Web‑App](https://products.aspose.app/slides/collage). Mit diesem Online‑Dienst können Sie [JPG zu JPG](https://products.aspose.app/slides/collage/jpg) oder PNG zu PNG‑Bilder zusammenführen, [Fotogitter](https://products.aspose.app/slides/collage/photo-grid) erstellen und vieles mehr. 

{{% /alert %}}

## **FAQ**

**Werden Notizen der Redner beim Merge erhalten?**

Ja. Beim Klonen von Folien übernimmt Aspose.Slides alle Folienelemente, einschließlich Notizen, Formatierungen und Animationen.

**Werden Kommentare und deren Autoren übertragen?**

Kommentare, als Teil des Folieninhalts, werden mit der Folie kopiert. Die Autoren‑Beschriftungen bleiben als Kommentarobjekte in der resultierenden Präsentation erhalten.

**Was geschieht, wenn die Quellpräsentation passwortgeschützt ist?**

Sie muss über das [Passwort geöffnet werden](/slides/de/python-net/password-protected-presentation/) mittels [LoadOptions.password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/); nach dem Laden können die Folien sicher in eine ungeschützte Zieldatei (oder ebenfalls in eine geschützte) geklont werden.

**Wie thread‑sicher ist der Merge‑Vorgang?**

Verwenden Sie dieselbe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Instanz nicht aus [mehreren Threads](/slides/de/python-net/multithreading/). Die empfohlene Regel lautet „ein Dokument – ein Thread“; verschiedene Dateien können parallel in separaten Threads verarbeitet werden.