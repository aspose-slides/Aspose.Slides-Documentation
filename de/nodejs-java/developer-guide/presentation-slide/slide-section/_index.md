---
title: Folienabschnitt
type: docs
weight: 90
url: /de/nodejs-java/slide-section/
---

Mit Aspose.Slides für Node.js via Java können Sie eine PowerPoint-Präsentation in Abschnitte organisieren. Sie können Abschnitte erstellen, die bestimmte Folien enthalten.

Sie möchten möglicherweise Abschnitte erstellen und diese verwenden, um Folien in einer Präsentation in logische Teile zu gliedern, z. B. in folgenden Situationen:

- Wenn Sie an einer großen Präsentation mit anderen Personen oder einem Team arbeiten – und Sie bestimmten Kollegen oder Teammitgliedern bestimmte Folien zuweisen müssen.  
- Wenn Sie mit einer Präsentation arbeiten, die viele Folien enthält – und Sie Schwierigkeiten haben, deren Inhalt auf einmal zu verwalten oder zu bearbeiten.

Idealerweise sollten Sie einen Abschnitt erstellen, der ähnliche Folien enthält – die Folien haben etwas gemeinsam oder können anhand einer Regel in einer Gruppe zusammengefasst werden – und dem Abschnitt einen Namen geben, der die Folien darin beschreibt.

## **Erstellen von Abschnitten in Präsentationen**

Um einen Abschnitt hinzuzufügen, der Folien in einer Präsentation enthält, bietet Aspose.Slides für Node.js via Java die [addSection()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SectionCollection#addSection-java.lang.String-aspose.slides.ISlide-)‑Methode, mit der Sie den Namen des zu erstellenden Abschnitts sowie die Folie, ab der der Abschnitt beginnt, angeben können.

Dieser Beispielcode zeigt Ihnen, wie Sie einen Abschnitt in einer Präsentation in JavaScript erstellen:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var defaultSlide = pres.getSlides().get_Item(0);
    var newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var section1 = pres.getSections().addSection("Section 1", newSlide1);
    var section2 = pres.getSections().addSection("Section 2", newSlide3);// section1 wird bei newSlide2 beendet und danach beginnt section2
    pres.save("pres-sections.pptx", aspose.slides.SaveFormat.Pptx);
    pres.getSections().reorderSectionWithSlides(section2, 0);
    pres.save("pres-sections-moved.pptx", aspose.slides.SaveFormat.Pptx);
    pres.getSections().removeSectionWithSlides(section2);
    pres.getSections().appendEmptySection("Last empty section");
    pres.save("pres-section-with-empty.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Ändern der Namen von Abschnitten**

Nachdem Sie einen Abschnitt in einer PowerPoint‑Präsentation erstellt haben, können Sie dessen Namen ändern.

Dieser Beispielcode zeigt Ihnen, wie Sie den Namen eines Abschnitts in einer Präsentation in JavaScript mit Aspose.Slides ändern:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var section = pres.getSections().get_Item(0);
    section.setName("My section");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Werden Abschnitte beim Speichern im PPT‑Format (PowerPoint 97–2003) erhalten?**

Nein. Das PPT‑Format unterstützt keine Abschnitts‑Metadaten, sodass die Abschnitts‑Gruppierung beim Speichern als *.ppt* verloren geht.

**Kann ein ganzer Abschnitt „ausgeblendet“ werden?**

Nein. Nur einzelne Folien können ausgeblendet werden. Ein Abschnitt als Einheit hat keinen „ausgeblendet“-Zustand.

**Kann ich einen Abschnitt schnell anhand einer Folie finden und umgekehrt die erste Folie eines Abschnitts ermitteln?**

Ja. Ein Abschnitt ist eindeutig durch seine Startfolie definiert; anhand einer Folie können Sie bestimmen, zu welchem Abschnitt sie gehört, und für einen Abschnitt können Sie auf seine erste Folie zugreifen.