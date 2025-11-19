---
title: Folienabschnitte in Präsentationen mit Python verwalten
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
description: "Optimieren Sie Folienabschnitte in PowerPoint und OpenDocument mit Aspose.Slides für Python - teilen, umbenennen und neu anordnen, um PPTX- und ODP-Workflows zu verbessern."
---

## **Übersicht**

Mit Aspose.Slides für Python können Sie eine PowerPoint-Präsentation in Abschnitte organisieren, die bestimmte Folien gruppieren.

Sie möchten möglicherweise Abschnitte erstellen, um eine Präsentation in logische Teile zu gliedern oder aufzuteilen, in folgenden Situationen:

- Wenn Sie an einer großen Präsentation mit einem Team arbeiten und bestimmte Folien bestimmten Kollegen zuweisen müssen.
- Wenn Sie mit einer Präsentation arbeiten, die viele Folien enthält, und es schwierig finden, alles auf einmal zu verwalten oder zu bearbeiten.

Idealerweise erstellen Sie Abschnitte, die zusammengehörige Folien gruppieren – solche, die ein gemeinsames Thema, einen gemeinsamen Gegenstand oder Zweck haben – und geben jedem Abschnitt einen Namen, der den Inhalt klar widerspiegelt. 

## **Abschnitte in Präsentationen erstellen**

Um einen [Section](https://reference.aspose.com/slides/python-net/aspose.slides/section/) hinzuzufügen, der Folien in einer Präsentation gruppiert, stellt Aspose.Slides die Methode [add_section](https://reference.aspose.com/slides/python-net/aspose.slides/sectioncollection/add_section/) bereit. Sie ermöglicht das Festlegen des Abschnittsnamens und der Folie, an der der Abschnitt beginnt.

Das folgende Python‑Beispiel zeigt, wie man einen Abschnitt in einer Präsentation erstellt:
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides[0]

    slide1 = presentation.slides.add_empty_slide(layout_slide)
    slide2 = presentation.slides.add_empty_slide(layout_slide)
    slide3 = presentation.slides.add_empty_slide(layout_slide)
    slide4 = presentation.slides.add_empty_slide(layout_slide)

    section1 = presentation.sections.add_section("Section 1", slide1)
    # Abschnitt 1 endet bei slide2; Abschnitt 2 beginnt bei slide3.
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

Das folgende Python‑Beispiel zeigt, wie man einen Abschnitt in einer Präsentation umbenennt:
```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
   section = presentation.sections[0]
   section.name = "My section"
```


## **FAQ**

**Werden Abschnitte beim Speichern im PPT‑Format (PowerPoint 97–2003) erhalten?**

Nein. Das PPT‑Format unterstützt keine Abschnitts‑Metadaten, sodass die Gruppierung von Abschnitten beim Speichern als .ppt verloren geht.

**Kann ein ganzer Abschnitt „ausgeblendet“ werden?**

Nein. Es können nur einzelne Folien ausgeblendet werden. Ein Abschnitt als Entität hat keinen „ausgeblendet“-Status.

**Kann ich schnell einen Abschnitt anhand einer Folie finden und umgekehrt die erste Folie eines Abschnitts?**

Ja. Ein Abschnitt ist eindeutig durch seine Startfolie definiert; anhand einer Folie lässt sich bestimmen, zu welchem Abschnitt sie gehört, und für einen Abschnitt kann man auf seine erste Folie zugreifen.