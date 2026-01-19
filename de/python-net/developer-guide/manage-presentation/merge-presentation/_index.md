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
description: "Müheloses Zusammenführen von PowerPoint- (PPT, PPTX) und OpenDocument- (ODP) Präsentationen mit Aspose.Slides für Python via .NET, zur Optimierung Ihres Workflows."
---

## **Optimieren Sie das Zusammenführen von Präsentationen**

Mit [Aspose.Slides for Python](https://products.aspose.com/slides/python-net/) können Sie PowerPoint‑Präsentationen nahtlos kombinieren und dabei Stile, Layouts und alle Elemente beibehalten. Im Gegensatz zu anderen Tools führt Aspose.Slides Präsentationen zusammen, ohne die Qualität zu beeinträchtigen oder Daten zu verlieren. Fassen Sie komplette Decks, einzelne Folien oder sogar verschiedene Dateiformate (z. B. PPT zu PPTX) zusammen.

### **Funktionen zum Zusammenführen**

- **Vollständiges Präsentations‑Merge:** Alle Folien zu einer einzigen Datei zusammenstellen.  
- **Spezifisches Folien‑Merge:** Ausgewählte Folien auswählen und kombinieren.  
- **Cross‑Format‑Merge:** Präsentationen unterschiedlicher Formate integrieren und dabei die Integrität bewahren.

## **Präsentationszusammenführung**

Wenn Sie eine Präsentation in eine andere zusammenführen, kombinieren Sie deren Folien zu einer einzigen Präsentation, um eine Datei zu erstellen. Die meisten Präsentationsprogramme – wie PowerPoint oder OpenOffice – bieten keine Funktionen, mit denen Sie Präsentationen auf diese Weise zusammenführen können.

Mit [Aspose.Slides for Python](https://products.aspose.com/slides/python-net/) können Sie jedoch Präsentationen auf verschiedene Arten zusammenführen. Sie können Präsentationen mit all ihren Formen, Stilen, Texten, Formatierungen, Kommentaren und Animationen zusammenführen, ohne Qualitäts- oder Datenverlust.

**See also**

[Klonoen Sie PowerPoint‑Folien in Python](/slides/de/python-net/clone-slides/)

### **Was kann zusammengeführt werden**

Mit Aspose.Slides können Sie Präsentationen zusammenführen:

- **Komplette Präsentationen:** Alle Folien der Quell‑Decks werden zu einer einzigen Präsentation kombiniert.  
- **Spezifische Folien:** Nur die ausgewählten Folien werden zu einer einzigen Präsentation kombiniert.  
- **Präsentationen desselben Formats** (z. B. PPT→PPT, PPTX→PPTX) **oder über verschiedene Formate** (z. B. PPT→PPTX, PPTX→ODP).

### **Zusammenführungsoptionen**

Sie können steuern, ob:

- Jede Folie in der Ausgabepäsentation ihren ursprünglichen Stil beibehält, oder  
- Ein einheitlicher Stil auf alle Folien der Ausgabepäsentation angewendet wird.

Um Präsentationen zusammenzuführen, stellt Aspose.Slides die Methoden [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) der Klasse [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) bereit. Diese Methodenüberladungen bestimmen, wie das Zusammenführen durchgeführt wird. Jedes [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Objekt stellt eine [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/)‑Sammlung bereit, sodass Sie `add_clone` auf der Folien‑Sammlung der Zielpräsentation aufrufen.

Die Methode `add_clone` gibt ein `Slide` zurück – eine Kopie der Quellfolie. Folien in der Ausgabepäsentation sind Kopien der Originale, sodass Sie die resultierenden Folien (z. B. Stile, Formatierungen oder Layouts anwenden) ändern können, ohne die Quellpräsentationen zu beeinflussen.

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

Aspose.Slides stellt die Methode [add_clone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide-asposeslidesimasterslide-bool) bereit, die es ermöglicht, Folien zusammenzuführen und dabei einen Folienmaster aus einer Vorlage anzuwenden. Auf diese Weise können Sie bei Bedarf die Folien in der Ausgabepäsentation neu gestalten.

Das folgende Python‑Beispiel demonstriert diesen Vorgang:
```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.masters[0], True)
        presentation1.save("combined_with_master.pptx", slides.export.SaveFormat.PPTX) 
```


{{% alert title="Note" color="warning" %}}
Das passende Layout unter dem angegebenen Folienmaster wird automatisch ermittelt. Wird kein geeignetes Layout gefunden und ist der boolesche Parameter `allow_clone_missing_layout` der Methode `add_clone` auf `True` gesetzt, wird stattdessen das Layout der Quellfolie verwendet. Andernfalls wird eine [PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/) ausgelöst.
{{% /alert %}}

Um ein anderes Folienlayout auf Folien in der Ausgabepäsentation anzuwenden, verwenden Sie beim Zusammenführen die Methode [add_clone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide-asposeslidesilayoutslide).

## **Bestimmte Folien aus Präsentationen zusammenführen**

Das Zusammenführen bestimmter Folien aus mehreren Präsentationen ist nützlich beim Erstellen benutzerdefinierter Foliensets. Aspose.Slides ermöglicht es Ihnen, nur die benötigten Folien auszuwählen und zu importieren, wobei die Formatierung, das Layout und das Design der Originalfolien erhalten bleiben.

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

Das folgende Python‑Beispiel zeigt, wie Folien aus mehreren Präsentationen zusammengeführt werden, wobei ein bestimmtes Folienlayout angewendet wird, um eine einzelne Ausgabepäsentation zu erzeugen:
```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.layout_slides[0])
        presentation1.save("combined_with_layout.pptx", slides.export.SaveFormat.PPTX) 
```


## **Präsentationen mit unterschiedlichen Foliengrößen zusammenführen**

{{% alert title="Note" color="warning" %}}
Sie können Präsentationen mit unterschiedlichen Foliengrößen nicht direkt zusammenführen.
{{% /alert %}}

Um zwei Präsentationen mit unterschiedlichen Foliengrößen zusammenzuführen, skalieren Sie zuerst eine Präsentation, sodass ihre Foliengröße der der anderen entspricht.

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

{{% alert title="Tip" color="primary" %}}
Suchen Sie nach einem schnellen und **kostenlosen Online‑Tool**, um **PowerPoint‑Präsentationen zusammenzuführen**? Probieren Sie den [**Aspose PowerPoint Merger**](https://products.aspose.app/slides/merger) aus.

- **PowerPoint‑Dateien einfach zusammenführen**: Kombinieren Sie mehrere **PPT, PPTX, ODP**‑Präsentationen zu einer einzigen Datei.  
- **Unterstützt verschiedene Formate**: Führen Sie **PPT zu PPTX**, **PPTX zu ODP** und mehr zusammen.  
- **Keine Installation erforderlich**: Funktioniert direkt in Ihrem Browser, schnell und sicher.  

[![Merge PowerPoint Files Online](slides-merger.png)](https://products.aspose.app/slides/merger)  

Beginnen Sie noch heute mit dem Zusammenführen Ihrer PowerPoint‑Dateien mit dem **kostenlosen Online‑Tool von Aspose**!
{{% /alert %}}

{{% alert title="Tip" color="primary" %}}
Aspose bietet eine [KOSTENLOSE Collage‑Web‑App](https://products.aspose.app/slides/collage) an. Mit diesem Online‑Dienst können Sie [JPG zu JPG](https://products.aspose.app/slides/collage/jpg) oder PNG zu PNG‑Bilder zusammenführen, [Fotogitter](https://products.aspose.app/slides/collage/photo-grid) erstellen und vieles mehr.
{{% /alert %}}

## **FAQ**

**Werden Sprecher‑Notizen beim Zusammenführen erhalten?**  
Ja. Beim Klonen von Folien überträgt Aspose.Slides alle Folienelemente, einschließlich Notizen, Formatierungen und Animationen.

**Werden Kommentare und deren Autoren übertragen?**  
Kommentare, als Teil des Folieninhalts, werden zusammen mit der Folie kopiert. Die Autor‑Labels der Kommentare bleiben im resultierenden Dokument als Kommentarobjekte erhalten.

**Was ist, wenn die Quellpräsentation passwortgeschützt ist?**  
Sie muss [mit dem Passwort geöffnet](/slides/de/python-net/password-protected-presentation/) werden, indem Sie [LoadOptions.password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/) verwenden; nach dem Laden können diese Folien sicher in eine ungeschützte Zieldatei (oder ebenfalls in eine geschützte) geklont werden.

**Wie thread‑sicher ist der Zusammenführungs‑Vorgang?**  
Verwenden Sie nicht dieselbe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Instanz aus [mehreren Threads](/slides/de/python-net/multithreading/). Die empfohlene Regel lautet „ein Dokument – ein Thread“; verschiedene Dateien können parallel in separaten Threads verarbeitet werden.