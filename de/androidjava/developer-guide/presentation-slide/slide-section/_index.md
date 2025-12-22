---
title: Slideabschnitte in Präsentationen auf Android verwalten
linktitle: Slide-Abschnitt
type: docs
weight: 90
url: /de/androidjava/slide-section/
keywords:
- Abschnitt erstellen
- Abschnitt hinzufügen
- Abschnitt bearbeiten
- Abschnitt ändern
- Abschnittsname
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Optimieren Sie Slide-Abschnitte in PowerPoint und OpenDocument mit Aspose.Slides für Android via Java – teilen, umbenennen und neu anordnen, um PPTX- und ODP-Workflows zu verbessern."
---

Mit Aspose.Slides für Android über Java können Sie eine PowerPoint‑Präsentation in Abschnitte unterteilen. Sie können Abschnitte erstellen, die bestimmte Folien enthalten.

Sie möchten möglicherweise Abschnitte erstellen und diese verwenden, um Folien in einer Präsentation in logische Teile zu organisieren oder zu trennen, in folgenden Situationen:

- Wenn Sie an einer großen Präsentation zusammen mit anderen Personen oder einem Team arbeiten – und Sie müssen bestimmten Folien einem Kollegen oder Teammitglied zuweisen.  
- Wenn Sie mit einer Präsentation arbeiten, die viele Folien enthält – und Sie Schwierigkeiten haben, deren Inhalte auf einmal zu verwalten oder zu bearbeiten.

Idealerweise sollten Sie einen Abschnitt erstellen, der ähnliche Folien enthält – die Folien haben etwas Gemeinsames oder können anhand einer Regel in einer Gruppe zusammengefasst werden – und dem Abschnitt einen Namen geben, der die darin enthaltenen Folien beschreibt.

## **Abschnitte in Präsentationen erstellen**

Um einen Abschnitt hinzuzufügen, der Folien in einer Präsentation enthält, stellt Aspose.Slides für Android über Java die Methode [addSection()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-) bereit, mit der Sie den Namen des zu erstellenden Abschnitts und die Folie, ab der der Abschnitt beginnt, angeben können.

Dieser Beispielcode zeigt, wie Sie in einer Java‑Präsentation einen Abschnitt erstellen:
```java
Presentation pres = new Presentation();
try {
    ISlide defaultSlide = pres.getSlides().get_Item(0);
    ISlide newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    ISection section1 = pres.getSections().addSection("Section 1", newSlide1);
    ISection section2 = pres.getSections().addSection("Section 2", newSlide3); // section1 wird bei newSlide2 beendet und danach beginnt section2

    pres.save("pres-sections.pptx", SaveFormat.Pptx);

    pres.getSections().reorderSectionWithSlides(section2, 0);
    pres.save("pres-sections-moved.pptx", SaveFormat.Pptx);

    pres.getSections().removeSectionWithSlides(section2);

    pres.getSections().appendEmptySection("Last empty section");

    pres.save("pres-section-with-empty.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Namen von Abschnitten ändern**

Nachdem Sie einen Abschnitt in einer PowerPoint‑Präsentation erstellt haben, können Sie dessen Namen ändern.

Dieser Beispielcode zeigt, wie Sie in einer Java‑Präsentation den Namen eines Abschnitts mit Aspose.Slides ändern:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    ISection section = pres.getSections().get_Item(0);
    section.setName("My section");
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Werden Abschnitte beim Speichern im PPT‑Format (PowerPoint 97–2003) beibehalten?**

Nein. Das PPT‑Format unterstützt keine Abschnitts‑Metadaten, sodass die Gruppierung von Abschnitten beim Speichern als .ppt verloren geht.

**Kann ein kompletter Abschnitt „ausgeblendet“ werden?**

Nein. Nur einzelne Folien können ausgeblendet werden. Ein Abschnitt als Entität hat keinen „ausgeblendet“-Zustand.

**Kann ich schnell einen Abschnitt anhand einer Folie finden und umgekehrt die erste Folie eines Abschnitts ermitteln?**

Ja. Ein Abschnitt wird eindeutig durch seine Startfolie definiert; anhand einer Folie können Sie bestimmen, zu welchem Abschnitt sie gehört, und für einen Abschnitt können Sie seine erste Folie abrufen.