---
title: Folienabschnitt
type: docs
weight: 100
url: /de/net/slide-section/
keywords: "Abschnitt erstellen, Abschnitt hinzufügen, Abschnittsnamen bearbeiten, PowerPoint-Präsentation, C#, Csharp, .NET, Aspose.Slides"
description: "Abschnitte in PowerPoint-Präsentation in C# oder .NET hinzufügen und bearbeiten"
---

Mit Aspose.Slides für .NET können Sie eine PowerPoint‑Präsentation in Abschnitte organisieren. Sie können Abschnitte erstellen, die bestimmte Folien enthalten. 

Sie möchten möglicherweise Abschnitte erstellen und sie verwenden, um Folien in einer Präsentation logisch zu gliedern oder zu teilen, in folgenden Situationen:

- Wenn Sie an einer großen Präsentation mit anderen Personen oder einem Team arbeiten – und bestimmten Folien einem Kollegen oder Teammitglied zuweisen müssen. 
- Wenn Sie eine Präsentation mit vielen Folien haben – und Schwierigkeiten haben, deren Inhalt auf einmal zu verwalten oder zu bearbeiten.

Idealerweise sollten Sie einen Abschnitt erstellen, der ähnliche Folien enthält – die Folien haben etwas gemeinsam oder können aufgrund einer Regel in einer Gruppe existieren – und dem Abschnitt einen Namen geben, der die Folien darin beschreibt. 

## **Erstellen von Abschnitten in Präsentationen**

Um einen Abschnitt hinzuzufügen, der Folien in einer Präsentation beherbergt, stellt Aspose.Slides für .NET die Methode AddSection bereit, mit der Sie den Namen des zu erstellenden Abschnitts und die Folie angeben können, an der der Abschnitt beginnt. 

Dieser Beispielcode zeigt, wie Sie in C# einen Abschnitt in einer Präsentation erstellen:
```c#
using (Presentation pres = new Presentation())
{
    ISlide defaultSlide = pres.Slides[0];
    ISlide newSlide1 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide2 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide3 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide4 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

    ISection section1 = pres.Sections.AddSection("Section 1", newSlide1);
    ISection section2 = pres.Sections.AddSection("Section 2", newSlide3); // section1 wird bei newSlide2 beendet und danach beginnt section2   
    
    pres.Save("pres-sections.pptx", SaveFormat.Pptx);
    
    pres.Sections.ReorderSectionWithSlides(section2, 0);
    pres.Save("pres-sections-moved.pptx", SaveFormat.Pptx);
    
    pres.Sections.RemoveSectionWithSlides(section2);
    
    pres.Sections.AppendEmptySection("Last empty section");
    
    pres.Save("pres-section-with-empty.pptx",SaveFormat.Pptx);
}
```


## **Ändern der Namen von Abschnitten**

Nachdem Sie einen Abschnitt in einer PowerPoint‑Präsentation erstellt haben, können Sie dessen Namen ändern. 

Dieser Beispielcode zeigt, wie Sie in C# mit Aspose.Slides den Namen eines Abschnitts in einer Präsentation ändern:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ISection section = pres.Sections[0];
   section.Name = "My section";
}
```


## **FAQ**

**Werden Abschnitte beim Speichern im PPT‑Format (PowerPoint 97–2003) beibehalten?**

Nein. Das PPT‑Format unterstützt keine Abschnitts‑Metadaten, sodass die Abschnitts‑Gruppierung beim Speichern in .ppt verloren geht.

**Kann ein ganzer Abschnitt „ausgeblendet“ werden?**

Nein. Nur einzelne Folien können ausgeblendet werden. Ein Abschnitt als Entität hat keinen „ausgeblendet“-Zustand.

**Kann ich schnell einen Abschnitt anhand einer Folie finden und umgekehrt die erste Folie eines Abschnitts?**

Ja. Ein Abschnitt ist eindeutig durch seine Anfangsfolie definiert; anhand einer Folie können Sie bestimmen, zu welchem Abschnitt sie gehört, und für einen Abschnitt können Sie seine erste Folie abrufen.