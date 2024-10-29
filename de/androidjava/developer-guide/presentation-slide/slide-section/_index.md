---
title: Folienabschnitt
type: docs
weight: 90
url: /de/androidjava/slide-section/
---

Mit Aspose.Slides für Android über Java können Sie eine PowerPoint-Präsentation in Abschnitte organisieren. Sie können Abschnitte erstellen, die bestimmte Folien enthalten.

Sie möchten möglicherweise Abschnitte erstellen und diese verwenden, um Folien in einer Präsentation in logische Teile zu organisieren oder zu unterteilen in diesen Situationen:

- Wenn Sie an einer großen Präsentation mit anderen Personen oder einem Team arbeiten—und Sie bestimmten Folien einem Kollegen oder einigen Teammitgliedern zuweisen müssen.
- Wenn Sie es mit einer Präsentation zu tun haben, die viele Folien enthält—und Sie Schwierigkeiten haben, deren Inhalte auf einmal zu verwalten oder zu bearbeiten.

Idealerweise sollten Sie einen Abschnitt erstellen, der ähnliche Folien beinhaltet—die Folien haben etwas gemeinsam oder sie können aufgrund einer Regel in einer Gruppe existieren—und dem Abschnitt einen Namen geben, der die Folien darin beschreibt.

## Erstellen von Abschnitten in Präsentationen

Um einen Abschnitt hinzuzufügen, der Folien in einer Präsentation beherbergt, bietet Aspose.Slides für Android über Java die [addSection()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-) Methode, mit der Sie den Namen des Abschnitts angeben können, den Sie erstellen möchten, und die Folie, von der der Abschnitt startet.

Dieser Beispielcode zeigt Ihnen, wie Sie einen Abschnitt in einer Präsentation in Java erstellen:

```java
Presentation pres = new Presentation();
try {
    ISlide defaultSlide = pres.getSlides().get_Item(0);
    ISlide newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    ISection section1 = pres.getSections().addSection("Abschnitt 1", newSlide1);
    ISection section2 = pres.getSections().addSection("Abschnitt 2", newSlide3); // section1 endet bei newSlide2 und danach startet section2   

    pres.save("pres-sections.pptx", SaveFormat.Pptx);

    pres.getSections().reorderSectionWithSlides(section2, 0);
    pres.save("pres-sections-moved.pptx", SaveFormat.Pptx);

    pres.getSections().removeSectionWithSlides(section2);

    pres.getSections().appendEmptySection("Letzter leerer Abschnitt");

    pres.save("pres-section-with-empty.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## Ändern der Namen von Abschnitten

Nachdem Sie einen Abschnitt in einer PowerPoint-Präsentation erstellt haben, möchten Sie möglicherweise seinen Namen ändern.

Dieser Beispielcode zeigt Ihnen, wie Sie den Namen eines Abschnitts in einer Präsentation in Java mit Aspose.Slides ändern:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ISection section = pres.getSections().get_Item(0);
    section.setName("Mein Abschnitt");
} finally {
    if (pres != null) pres.dispose();
}
```