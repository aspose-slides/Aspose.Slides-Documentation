---
title: Slide-Abschnitte in Präsentationen mit Java verwalten
linktitle: Slide-Abschnitt
type: docs
weight: 90
url: /de/java/slide-section/
keywords:
- Abschnitt erstellen
- Abschnitt hinzufügen
- Abschnitt bearbeiten
- Abschnitt ändern
- Abschnittsname
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Optimieren Sie Slide-Abschnitte in PowerPoint und OpenDocument mit Aspose.Slides für Java - teilen, umbenennen und neu anordnen, um PPTX- und ODP-Workflows zu verbessern."
---

Mit Aspose.Slides für Java können Sie eine PowerPoint‑Präsentation in Abschnitte gliedern. Sie können Abschnitte erstellen, die bestimmte Folien enthalten. 

Sie möchten möglicherweise Abschnitte erstellen und sie verwenden, um Folien in einer Präsentation in logische Teile zu organisieren oder zu unterteilen, in folgenden Situationen:

- Wenn Sie an einer umfangreichen Präsentation mit anderen Personen oder einem Team arbeiten – und bestimmte Folien einem Kollegen oder mehreren Teammitgliedern zuweisen müssen. 
- Wenn Sie mit einer Präsentation zu tun haben, die viele Folien enthält – und Sie Schwierigkeiten haben, deren Inhalt auf einmal zu verwalten oder zu bearbeiten.

Idealerweise sollten Sie einen Abschnitt erstellen, der ähnliche Folien enthält – die Folien haben etwas gemeinsam oder können anhand einer Regel in einer Gruppe zusammengefasst werden – und dem Abschnitt einen Namen geben, der die darin enthaltenen Folien beschreibt. 

## **Abschnitte in Präsentationen erstellen**

Um einen Abschnitt hinzuzufügen, der Folien in einer Präsentation enthält, stellt Aspose.Slides für Java die Methode [addSection()](https://reference.aspose.com/slides/java/com.aspose.slides/ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-) bereit, mit der Sie den Namen des zu erstellenden Abschnitts und die Folie, ab der der Abschnitt beginnt, angeben können. 

Der folgende Beispielcode zeigt, wie Sie in Java einen Abschnitt in einer Präsentation erstellen:
```java
Presentation pres = new Presentation();
try {
    ISlide defaultSlide = pres.getSlides().get_Item(0);
    ISlide newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    ISection section1 = pres.getSections().addSection("Section 1", newSlide1);
    ISection section2 = pres.getSections().addSection("Section 2", newSlide3); // section1 wird bei newSlide2 beendet und danach startet section2   

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

Der folgende Beispielcode zeigt, wie Sie mit Aspose.Slides in Java den Namen eines Abschnitts in einer Präsentation ändern:
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

**Werden Abschnitte beim Speichern im PPT‑Format (PowerPoint 97–2003) erhalten?**

Nein. Das PPT‑Format unterstützt keine Abschnitts‑Metadaten, sodass die Abschnitts‑Gruppierung beim Speichern als .ppt verloren geht.

**Kann ein ganzer Abschnitt "ausgeblendet" werden?**

Nein. Nur einzelne Folien können ausgeblendet werden. Ein Abschnitt als Entität hat keinen "ausgeblendet"-Zustand.

**Kann ich einen Abschnitt schnell über eine Folie finden und umgekehrt die erste Folie eines Abschnitts?**

Ja. Ein Abschnitt ist eindeutig durch seine Startfolie definiert; anhand einer Folie können Sie bestimmen, zu welchem Abschnitt sie gehört, und für einen Abschnitt können Sie auf seine erste Folie zugreifen.