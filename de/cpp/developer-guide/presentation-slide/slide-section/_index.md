---
title: Verwalten von Folienabschnitten in Präsentationen mit C++
linktitle: Folienabschnitt
type: docs
weight: 100
url: /de/cpp/slide-section/
keywords:
- Abschnitt erstellen
- Abschnitt hinzufügen
- Abschnitt bearbeiten
- Abschnitt ändern
- Abschnittsname
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Optimieren Sie Folienabschnitte in PowerPoint und OpenDocument mit Aspose.Slides für C++ – teilen, umbenennen und neu anordnen, um PPTX- und ODP-Workflows zu verbessern."
---

Mit Aspose.Slides für C++ können Sie eine PowerPoint-Präsentation in Abschnitte organisieren. Sie können Abschnitte erstellen, die bestimmte Folien enthalten. 

Sie möchten möglicherweise Abschnitte erstellen und diese verwenden, um Folien in einer Präsentation in logische Teile zu organisieren oder zu unterteilen, in den folgenden Situationen:

- Wenn Sie an einer großen Präsentation mit anderen Personen oder einem Team arbeiten – und bestimmte Folien einem Kollegen oder einigen Teammitgliedern zuweisen müssen. 
- Wenn Sie mit einer Präsentation zu tun haben, die viele Folien enthält – und Sie Schwierigkeiten haben, deren Inhalte auf einmal zu verwalten oder zu bearbeiten.

Idealerweise sollten Sie einen Abschnitt erstellen, der ähnliche Folien enthält – die Folien haben etwas gemeinsam oder können anhand einer Regel in einer Gruppe zusammengefasst werden – und dem Abschnitt einen Namen geben, der die enthaltenen Folien beschreibt. 

## **Abschnitte in Präsentationen erstellen**

Um einen Abschnitt hinzuzufügen, der Folien in einer Präsentation enthält, stellt Aspose.Slides für C++ die Methode AddSection bereit, mit der Sie den Namen des zu erstellenden Abschnitts sowie die Folie, bei der der Abschnitt beginnt, angeben können. 

Dieser Beispielcode zeigt, wie Sie in C++ einen Abschnitt in einer Präsentation erstellen:
``` cpp
auto pres = System::MakeObject<Presentation>();

auto defaultSlide = pres->get_Slides()->idx_get(0);
auto newSlide1 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide2 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide3 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide4 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));

auto section1 = pres->get_Sections()->AddSection(u"Section 1", newSlide1);
auto section2 = pres->get_Sections()->AddSection(u"Section 2", newSlide3);
// section1 wird bei newSlide2 beendet und danach beginnt section2   
pres->Save(u"pres-sections.pptx", SaveFormat::Pptx);

pres->get_Sections()->ReorderSectionWithSlides(section2, 0);
pres->Save(u"pres-sections-moved.pptx", SaveFormat::Pptx);

pres->get_Sections()->RemoveSectionWithSlides(section2);

pres->get_Sections()->AppendEmptySection(u"Last empty section");

pres->Save(u"pres-section-with-empty.pptx", SaveFormat::Pptx);
```


## **Namen von Abschnitten ändern**

Nachdem Sie einen Abschnitt in einer PowerPoint-Präsentation erstellt haben, können Sie dessen Namen ändern. 

Dieser Beispielcode zeigt, wie Sie den Namen eines Abschnitts in einer Präsentation in C++ mithilfe von Aspose.Slides ändern:
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto section = pres->get_Sections()->idx_get(0);
section->set_Name(u"My section");
```


## **FAQ**

**Werden Abschnitte beim Speichern im PPT (PowerPoint 97–2003) Format erhalten?**

Nein. Das PPT-Format unterstützt keine Abschnitts‑Metadaten, sodass die Abschnitts‑Gruppierung beim Speichern als .ppt verloren geht.

**Kann ein ganzer Abschnitt „ausgeblendet“ werden?**

Nein. Es können nur einzelne Folien ausgeblendet werden. Ein Abschnitt als Entität hat keinen „ausgeblendet“-Zustand.

**Kann ich schnell einen Abschnitt anhand einer Folie finden und umgekehrt die erste Folie eines Abschnitts?**

Ja. Ein Abschnitt ist eindeutig durch seine Startfolie definiert; anhand einer Folie können Sie bestimmen, zu welchem Abschnitt sie gehört, und für einen Abschnitt können Sie seine erste Folie abrufen.