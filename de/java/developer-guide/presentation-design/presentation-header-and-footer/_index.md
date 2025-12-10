---
title: Verwalten von Präsentationskopf‑ und ‑fußzeilen in Java
linktitle: Kopf‑ und Fußzeile
type: docs
weight: 140
url: /de/java/presentation-header-and-footer/
keywords:
- Kopfzeile
- Kopfzeilentext
- Fußzeile
- Fußzeilentext
- Kopfzeile setzen
- Fußzeile setzen
- Handzettel
- Notizen
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Verwenden Sie Aspose.Slides für Java, um Kopf‑ und Fußzeilen in PowerPoint‑ und OpenDocument‑Präsentationen hinzuzufügen und anzupassen, um ein professionelles Aussehen zu erzielen."
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/de/java/) bietet Unterstützung für die Arbeit mit Kopf‑ und Fußzeilentexten von Folien, die tatsächlich auf Folienmaster‑Ebene verwaltet werden.

{{% /alert %}} 

[Aspose.Slides for Java](/slides/de/java/) bietet die Funktion zum Verwalten von Kopf‑ und Fußzeilen innerhalb von Präsentationsfolien. Diese werden tatsächlich auf Präsentationsmaster‑Ebene verwaltet.

## **Kopf‑ und Fußzeilen in einer Präsentation verwalten**
Notizen einer bestimmten Folie können wie im folgenden Beispiel entfernt werden:
```java
// Präsentation laden
Presentation pres = new Presentation("headerTest.pptx");
try {
    // Fußzeile setzen
    pres.getHeaderFooterManager().setAllFootersText("My Footer text");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);

    // Zugriff und Aktualisierung der Kopfzeile
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (null != masterNotesSlide)
    {
        updateHeaderFooterText(masterNotesSlide);
    }

    // Präsentation speichern
    pres.save("HeaderFooterJava.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

```java
// Methode zum Setzen von Header-/Footer-Text
public static void updateHeaderFooterText(IBaseSlide master)
{
    for (IShape shape : master.getShapes())
    {
        if (shape.getPlaceholder() != null)
        {
            if (shape.getPlaceholder().getType() == PlaceholderType.Header)
            {
                ((IAutoShape)shape).getTextFrame().setText("HI there new header");
            }
        }
    }
}
```


## **Kopf‑ und Fußzeilen in Handouts und Notizfolien verwalten**
Aspose.Slides for Java unterstützt Kopf‑ und Fußzeilen in Handouts und Notizfolien. Bitte folgen Sie den nachstehenden Schritten:

- Laden Sie eine [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) mit einem Video.
- Ändern Sie die Kopf‑ und Fußzeileneinstellungen für den Notizen‑Master und alle Notizfolien.
- Setzen Sie den Master‑Notizfolien‑ und alle untergeordneten Fußzeilen‑Platzhalter sichtbar.
- Setzen Sie den Master‑Notizfolien‑ und alle untergeordneten Datums‑ und Zeit‑Platzhalter sichtbar.
- Ändern Sie die Kopf‑ und Fußzeileneinstellungen nur für die erste Notizfolie.
- Setzen Sie den Notizfolien‑Kopfzeilen‑Platzhalter sichtbar.
- Setzen Sie den Text im Notizfolien‑Kopfzeilen‑Platzhalter.
- Setzen Sie den Text im Notizfolien‑Datum‑Zeit‑Platzhalter.
- Schreiben Sie die geänderte Präsentationsdatei.

Code‑Snippet im nachstehenden Beispiel bereitgestellt.
```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // Header- und Fußzeileneinstellungen für den Notizen-Master und alle Notizfolien ändern
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // macht den Master-Notizen-Slide und alle untergeordneten Footer-Platzhalter sichtbar
        headerFooterManager.setFooterAndChildFootersVisibility(true); // macht den Master-Notizen-Slide und alle untergeordneten Header-Platzhalter sichtbar
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // macht den Master-Notizen-Slide und alle untergeordneten Foliennummer-Platzhalter sichtbar
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // macht den Master-Notizen-Slide und alle untergeordneten Datums- und Zeit-Platzhalter sichtbar

        headerFooterManager.setHeaderAndChildHeadersText("Header text"); // setzt Text für den Master-Notizen-Slide und alle untergeordneten Header-Platzhalter
        headerFooterManager.setFooterAndChildFootersText("Footer text"); // setzt Text für den Master-Notizen-Slide und alle untergeordneten Footer-Platzhalter
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text"); // setzt Text für den Master-Notizen-Slide und alle untergeordneten Datums- und Zeit-Platzhalter
    }

    // Header- und Fußzeileneinstellungen nur für die erste Notizfolie ändern
    INotesSlide notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null)
    {
        INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible())
            headerFooterManager.setHeaderVisibility(true); // macht diesen Notizen-Slide Header-Platzhalter sichtbar

        if (!headerFooterManager.isFooterVisible())
            headerFooterManager.setFooterVisibility(true); // macht diesen Notizen-Slide Footer-Platzhalter sichtbar

        if (!headerFooterManager.isSlideNumberVisible())
            headerFooterManager.setSlideNumberVisibility(true); // macht diesen Notizen-Slide Foliennummer-Platzhalter sichtbar

        if (!headerFooterManager.isDateTimeVisible())
            headerFooterManager.setDateTimeVisibility(true); // macht diesen Notizen-Slide Datum‑Zeit-Platzhalter sichtbar

        headerFooterManager.setHeaderText("New header text"); // setzt Text für den Notizen-Slide Header-Platzhalter
        headerFooterManager.setFooterText("New footer text"); // setzt Text für den Notizen-Slide Footer-Platzhalter
        headerFooterManager.setDateTimeText("New date and time text"); // setzt Text für den Notizen-Slide Datum‑Zeit-Platzhalter
    }
    pres.save("testresult.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Kann ich einer normalen Folie eine "Kopfzeile" hinzufügen?**

In PowerPoint existiert "Header" nur für Notizen und Handouts; in normalen Folien sind die unterstützten Elemente die Fußzeile, Datum/Uhrzeit und Foliennummer. In Aspose.Slides entspricht dies denselben Einschränkungen: Header nur für Notes/Handout und in Folien — Footer/DateTime/SlideNumber.

**Was ist, wenn das Layout keinen Fußzeilenbereich enthält – kann ich dessen Sichtbarkeit "einschalten"?**

Ja. Überprüfen Sie die Sichtbarkeit über den Kopf‑/Fußzeilen‑Manager und aktivieren Sie sie bei Bedarf. Diese API‑Indikatoren und Methoden sind für Fälle vorgesehen, in denen der Platzhalter fehlt oder ausgeblendet ist.

**Wie kann ich die Foliennummer von einem Wert anders als 1 starten lassen?**

Setzen Sie die [erste Foliennummer](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-) der Präsentation; danach wird die gesamte Nummerierung neu berechnet. Beispielsweise können Sie bei 0 oder 10 beginnen und die Nummer auf der Titelfolie ausblenden.

**Was passiert mit Kopf‑ und Fußzeilen beim Exportieren nach PDF/Bildern/HTML?**

Sie werden als reguläre Textelemente der Präsentation gerendert. Das bedeutet, wenn die Elemente auf Folien/Notizseiten sichtbar sind, erscheinen sie auch im Ausgabeformat zusammen mit dem restlichen Inhalt.