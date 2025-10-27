---
title: Verwalten von Folienabschnitten in Präsentationen mit Python
linktitle: Folienabschnitt
type: docs
weight: 100
url: /de/python-net/slide-section/
keywords:
- Abschnitt erstellen
- Abschnitt hinzufügen
- Abschnitt bearbeiten
- Abschnitt ändern
- Abschnittsname
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Optimieren Sie Folienabschnitte in PowerPoint und OpenDocument mit Aspose.Slides für Python – teilen, umbenennen und neu anordnen, um PPTX- und ODP-Workflows zu verbessern."
---

## **Übersicht**

Mit Aspose.Slides für Python können Sie eine PowerPoint‑Präsentation in Abschnitte gliedern, die bestimmte Folien gruppieren.

Sie möchten möglicherweise Abschnitte erstellen, um eine Präsentation in logische Teile zu gliedern, in folgenden Situationen:

- Wenn Sie an einer großen Präsentation mit einem Team arbeiten und bestimmten Folien bestimmten Kolleg*innen zuweisen müssen.
- Wenn Sie mit einer Präsentation arbeiten, die viele Folien enthält, und es schwierig finden, alles auf einmal zu verwalten oder zu bearbeiten.

Idealerweise erstellen Sie Abschnitte, die zusammengehörige Folien gruppieren – solche, die ein gemeinsames Thema, einen gemeinsamen Gegenstand oder Zweck teilen – und geben jedem Abschnitt einen Namen, der den Inhalt klar widerspiegelt. 

## **Abschnitte in Präsentationen erstellen**

Um einer Präsentation einen [Section](https://reference.aspose.com/slides/python-net/aspose.slides/section/) (Abschnitt) hinzuzufügen, der Folien gruppiert, stellt Aspose.Slides die Methode [add_section](https://reference.aspose.com/slides/python-net/aspose.slides/sectioncollection/add_section/) bereit. Sie ermöglicht das Festlegen des Abschnittsnamens und der Folie, an der der Abschnitt beginnt.

Das folgende Python‑Beispiel zeigt, wie ein Abschnitt in einer Präsentation erstellt wird:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides[0]

    slide1 = presentation.slides.add_empty_slide(layout_slide)
    slide2 = presentation.slides.add_empty_slide(layout_slide)
    slide3 = presentation.slides.add_empty_slide(layout_slide)
    slide4 = presentation.slides.add_empty_slide(layout_slide)

    section1 = presentation.sections.add_section("Section 1", slide1)
    # Section 1 ends at slide2; Section 2 starts at slide3.
    section2 = presentation.sections.add_section("Section 2", slide3) 
      
    presentation.save("presentation_sections.pptx", slides.export.SaveFormat.PPTX)
    
    presentation.sections.reorder_section_with_slides(section2, 0)
    presentation.save("reordered_sections.pptx", slides.export.SaveFormat.PPTX)
    
    presentation.sections.remove_section_with_slides(section2)
    presentation.sections.append_empty_section("Last empty section")
    presentation.save("presentation_with_empty_section.pptx",slides.export.SaveFormat.PPTX)
```

## **Namen von Abschnitten ändern**

Nachdem Sie einen [Section](https://reference.aspose.com/slides/python-net/aspose.slides/section/) in einer PowerPoint‑Präsentation erstellt haben, können Sie dessen Namen ändern.

Das folgende Python‑Beispiel zeigt, wie ein Abschnitt in einer Präsentation umbenannt wird:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
   section = presentation.sections[0]
   section.name = "My section"
```

## **FAQ**

**Werden Abschnitte beim Speichern im PPT (PowerPoint 97–2003) Format beibehalten?**

Nein. Das PPT‑Format unterstützt keine Abschnitts‑Metadaten, daher geht die Gruppierung von Abschnitten beim Speichern als .ppt verloren.

**Kann ein ganzer Abschnitt „ausgeblendet“ werden?**

Nein. Nur einzelne Folien können ausgeblendet werden. Ein Abschnitt als Entität hat keinen „ausgeblendet“-Zustand.

**Kann ich einen Abschnitt schnell über eine Folie finden und umgekehrt die erste Folie eines Abschnitts ermitteln?**

Ja. Ein Abschnitt wird eindeutig durch seine Startfolie definiert; anhand einer Folie lässt sich ermitteln, zu welchem Abschnitt sie gehört, und zu einem Abschnitt kann man seine erste Folie abrufen.