---
title: Verwalten von Folienabschnitten in Präsentationen in .NET
linktitle: Folienabschnitt
type: docs
weight: 100
url: /de/net/slide-section/
keywords:
- Abschnitt erstellen
- Abschnitt hinzufügen
- Abschnitt bearbeiten
- Abschnitt ändern
- Abschnittsname
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Vereinfachen Sie Folienabschnitte in PowerPoint und OpenDocument mit Aspose.Slides für .NET - teilen, umbenennen und neu anordnen, um PPTX- und ODP-Arbeitsabläufe zu optimieren."
---

Mit Aspose.Slides für .NET können Sie eine PowerPoint‑Präsentation in Abschnitte unterteilen. Sie können Abschnitte erstellen, die bestimmte Folien enthalten.

Sie möchten Abschnitte erstellen und diese verwenden, um Folien in einer Präsentation in logische Teile zu organisieren oder zu teilen, in folgenden Situationen:

- Wenn Sie an einer großen Präsentation zusammen mit anderen Personen oder einem Team arbeiten – und bestimmten Folien einem Kollegen oder mehreren Teammitgliedern zuweisen müssen.  
- Wenn Sie mit einer Präsentation arbeiten, die viele Folien enthält – und Sie Schwierigkeiten haben, deren Inhalte auf einmal zu verwalten oder zu bearbeiten.

Idealerweise sollten Sie einen Abschnitt erstellen, der ähnliche Folien enthält – die Folien haben etwas Gemeinsames oder können anhand einer Regel in einer Gruppe zusammengefasst werden – und dem Abschnitt einen Namen geben, der die darin enthaltenen Folien beschreibt.

## **Abschnitte in Präsentationen erstellen**

Um einen Abschnitt hinzuzufügen, der Folien in einer Präsentation enthält, stellt Aspose.Slides für .NET die Methode **AddSection** bereit, mit der Sie den Namen des zu erstellenden Abschnitts und die Folie, an der der Abschnitt beginnt, angeben können.

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
    ISection section2 = pres.Sections.AddSection("Section 2", newSlide3); // section1 wird bei newSlide2 beendet und danach startet section2   
    
    pres.Save("pres-sections.pptx", SaveFormat.Pptx);
    
    pres.Sections.ReorderSectionWithSlides(section2, 0);
    pres.Save("pres-sections-moved.pptx", SaveFormat.Pptx);
    
    pres.Sections.RemoveSectionWithSlides(section2);
    
    pres.Sections.AppendEmptySection("Last empty section");
    
    pres.Save("pres-section-with-empty.pptx",SaveFormat.Pptx);
}
```


## **Namen von Abschnitten ändern**

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

Nein. Das PPT‑Format unterstützt keine Abschnittsmetadaten, sodass die Abschnittsgruppierung beim Speichern als .ppt verloren geht.

**Kann ein ganzer Abschnitt „ausgeblendet“ werden?**

Nein. Nur einzelne Folien können ausgeblendet werden. Ein Abschnitt als Entität hat keinen „ausgeblendet“-Zustand.

**Kann ich schnell einen Abschnitt über eine Folie finden und umgekehrt die erste Folie eines Abschnitts?**

Ja. Ein Abschnitt ist eindeutig durch seine Startfolie definiert; anhand einer Folie können Sie ermitteln, zu welchem Abschnitt sie gehört, und zu einem Abschnitt können Sie auf seine erste Folie zugreifen.