---
title: Abschnitt hinzufügen
type: docs
weight: 100
url: /net/slide-section/
keywords: "Abschnitt erstellen, Abschnitt hinzufügen, Abschnittsnamen bearbeiten, PowerPoint-Präsentation, C#, Csharp, .NET, Aspose.Slides"
description: "Abschnitt in PowerPoint-Präsentation in C# oder .NET hinzufügen und bearbeiten"
---

Mit Aspose.Slides für .NET können Sie eine PowerPoint-Präsentation in Abschnitte organisieren. Sie können Abschnitte erstellen, die bestimmte Folien enthalten.

Sie möchten möglicherweise Abschnitte erstellen und diese verwenden, um Folien in einer Präsentation in logische Teile zu organisieren oder zu unterteilen in diesen Situationen:

- Wenn Sie an einer großen Präsentation mit anderen Personen oder einem Team arbeiten – und Sie bestimmten Folien einem Kollegen oder einigen Teammitgliedern zuweisen müssen.
- Wenn Sie es mit einer Präsentation zu tun haben, die viele Folien enthält – und Sie Schwierigkeiten haben, deren Inhalte gleichzeitig zu verwalten oder zu bearbeiten.

Idealerweise sollten Sie einen Abschnitt erstellen, der ähnliche Folien enthält – die Folien haben etwas gemeinsam oder können basierend auf einer Regel in einer Gruppe existieren – und dem Abschnitt einen Namen geben, der die Folien darin beschreibt.

## Abschnitte in Präsentationen erstellen

Um einen Abschnitt hinzuzufügen, der Folien in einer Präsentation enthält, bietet Aspose.Slides für .NET die Methode AddSection, mit der Sie den Namen des Abschnitts angeben können, den Sie erstellen möchten, und die Folie, von der der Abschnitt beginnt.

Dieser Beispielcode zeigt Ihnen, wie Sie einen Abschnitt in einer Präsentation in C# erstellen:

```c#
using (Presentation pres = new Presentation())
{
    ISlide defaultSlide = pres.Slides[0];
    ISlide newSlide1 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide2 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide3 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide4 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

    ISection section1 = pres.Sections.AddSection("Abschnitt 1", newSlide1);
    ISection section2 = pres.Sections.AddSection("Abschnitt 2", newSlide3); // section1 endet an newSlide2 und danach beginnt section2   
    
    pres.Save("pres-sections.pptx", SaveFormat.Pptx);
    
    pres.Sections.ReorderSectionWithSlides(section2, 0);
    pres.Save("pres-sections-moved.pptx", SaveFormat.Pptx);
    
    pres.Sections.RemoveSectionWithSlides(section2);
    
    pres.Sections.AppendEmptySection("Letzter leerer Abschnitt");
    
    pres.Save("pres-section-with-empty.pptx",SaveFormat.Pptx);
}
```

## Namen von Abschnitten ändern

Nachdem Sie einen Abschnitt in einer PowerPoint-Präsentation erstellt haben, können Sie entscheiden, seinen Namen zu ändern.

Dieser Beispielcode zeigt Ihnen, wie Sie den Namen eines Abschnitts in einer Präsentation in C# mit Aspose.Slides ändern:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ISection section = pres.Sections[0];
   section.Name = "Mein Abschnitt";
}
```