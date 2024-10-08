---
title: Abschnitt Folien
type: docs
weight: 100
url: /de/cpp/slide-section/
---

Mit Aspose.Slides für C++ können Sie eine PowerPoint-Präsentation in Abschnitte organisieren. Sie können Abschnitte erstellen, die spezifische Folien enthalten.

Sie möchten möglicherweise Abschnitte erstellen und diese verwenden, um Folien in einer Präsentation in logische Teile zu organisieren oder zu unterteilen in diesen Situationen:

- Wenn Sie an einer großen Präsentation mit anderen Personen oder einem Team arbeiten – und Sie bestimmten Folien einem Kollegen oder einigen Teammitgliedern zuweisen müssen.
- Wenn Sie mit einer Präsentation arbeiten, die viele Folien enthält – und Sie Schwierigkeiten haben, den Inhalt auf einmal zu verwalten oder zu bearbeiten.

Idealerweise sollten Sie einen Abschnitt erstellen, der ähnliche Folien enthält – die Folien haben etwas gemeinsam oder können basierend auf einer Regel in einer Gruppe existieren – und dem Abschnitt einen Namen geben, der die Folien darin beschreibt.

## Abschnitte in Präsentationen erstellen

Um einen Abschnitt hinzuzufügen, der Folien in einer Präsentation beherbergt, bietet Aspose.Slides für C++ die Methode AddSection, mit der Sie den Namen des Abschnitts, den Sie erstellen möchten, und die Folie, von der der Abschnitt beginnt, angeben können.

Dieser Beispielcode zeigt Ihnen, wie Sie einen Abschnitt in einer Präsentation in C++ erstellen:

``` cpp
auto pres = System::MakeObject<Presentation>();

auto defaultSlide = pres->get_Slides()->idx_get(0);
auto newSlide1 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide2 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide3 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide4 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));

auto section1 = pres->get_Sections()->AddSection(u"Abschnitt 1", newSlide1);
auto section2 = pres->get_Sections()->AddSection(u"Abschnitt 2", newSlide3);
// section1 endet bei newSlide2 und danach beginnt section2   

pres->Save(u"pres-sections.pptx", SaveFormat::Pptx);

pres->get_Sections()->ReorderSectionWithSlides(section2, 0);
pres->Save(u"pres-sections-moved.pptx", SaveFormat::Pptx);

pres->get_Sections()->RemoveSectionWithSlides(section2);

pres->get_Sections()->AppendEmptySection(u"Letzter leerer Abschnitt");

pres->Save(u"pres-section-with-empty.pptx", SaveFormat::Pptx);
```

## Ändern der Namen von Abschnitten

Nachdem Sie einen Abschnitt in einer PowerPoint-Präsentation erstellt haben, möchten Sie möglicherweise entscheiden, seinen Namen zu ändern.

Dieser Beispielcode zeigt Ihnen, wie Sie den Namen eines Abschnitts in einer Präsentation in C++ mithilfe von Aspose.Slides ändern können:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto section = pres->get_Sections()->idx_get(0);
section->set_Name(u"Mein Abschnitt");
```