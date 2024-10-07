---
title: Folienabschnitt
type: docs
weight: 100
url: /python-net/slide-section/
keywords: "Abschnitt erstellen, Abschnitt hinzufügen, Abschnittsname bearbeiten, PowerPoint-Präsentation, Python, Aspose.Slides"
description: "Abschnitt in PowerPoint-Präsentation in Python hinzufügen und bearbeiten"
---

Mit Aspose.Slides für Python über .NET können Sie eine PowerPoint-Präsentation in Abschnitte organisieren. Sie können Abschnitte erstellen, die bestimmte Folien enthalten.

Sie möchten möglicherweise Abschnitte erstellen und diese verwenden, um Folien in einer Präsentation in logische Teile zu organisieren oder zu unterteilen in folgenden Situationen:

- Wenn Sie an einer großen Präsentation mit anderen Personen oder einem Team arbeiten und bestimmte Folien einem Kollegen oder einigen Teammitgliedern zuweisen müssen.
- Wenn Sie es mit einer Präsentation zu tun haben, die viele Folien enthält, und es Ihnen schwerfällt, deren Inhalt auf einmal zu verwalten oder zu bearbeiten.

Idealerweise sollten Sie einen Abschnitt erstellen, der ähnliche Folien enthält – die Folien haben etwas gemeinsam oder können basierend auf einer Regel in einer Gruppe existieren – und dem Abschnitt einen Namen geben, der die Folien darin beschreibt.

## Abschnitte in Präsentationen erstellen

Um einen Abschnitt hinzuzufügen, der Folien in einer Präsentation beherbergt, stellt Aspose.Slides für Python über .NET die Methode AddSection zur Verfügung, die es Ihnen ermöglicht, den Namen des Abschnitts, den Sie erstellen möchten, sowie die Folie, von der aus der Abschnitt beginnt, anzugeben.

Dieser Beispielcode zeigt Ihnen, wie man einen Abschnitt in einer Präsentation in Python erstellt:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    defaultSlide = pres.slides[0]
    newSlide1 = pres.slides.add_empty_slide(pres.layout_slides[0])
    newSlide2 = pres.slides.add_empty_slide(pres.layout_slides[0])
    newSlide3 = pres.slides.add_empty_slide(pres.layout_slides[0])
    newSlide4 = pres.slides.add_empty_slide(pres.layout_slides[0])

    section1 = pres.sections.add_section("Abschnitt 1", newSlide1)
    # section1 wird an newSlide2 enden und danach wird section2 beginnen
    section2 = pres.sections.add_section("Abschnitt 2", newSlide3)
      
    
    pres.save("pres-sections.pptx", slides.export.SaveFormat.PPTX)
    
    pres.sections.reorder_section_with_slides(section2, 0)
    pres.save("pres-sections-moved.pptx", slides.export.SaveFormat.PPTX)
    
    pres.sections.remove_section_with_slides(section2)
    
    pres.sections.append_empty_section("Letzter leerer Abschnitt")
    
    pres.save("pres-section-with-empty.pptx",slides.export.SaveFormat.PPTX)
```

## Die Namen von Abschnitten ändern

Nachdem Sie einen Abschnitt in einer PowerPoint-Präsentation erstellt haben, möchten Sie möglicherweise dessen Namen ändern.

Dieser Beispielcode zeigt Ihnen, wie Sie den Namen eines Abschnitts in einer Präsentation in Python mit Aspose.Slides ändern können:

```py
import aspose.slides as slides

with slides.Presentation("pres-sections.pptx") as pres:
   section = pres.sections[0]
   section.name = "Mein Abschnitt"
```