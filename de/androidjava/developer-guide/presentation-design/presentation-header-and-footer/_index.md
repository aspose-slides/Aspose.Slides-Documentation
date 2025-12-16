---
title: Verwalten von Präsentationskopf- und -fußzeilen unter Android
linktitle: Kopfzeile & Fußzeile
type: docs
weight: 140
url: /de/androidjava/presentation-header-and-footer/
keywords:
- Kopfzeile
- Kopfzeilentext
- Fußzeile
- Fußzeilentext
- Kopfzeile setzen
- Fußzeile setzen
- Handout
- Notizen
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Verwenden Sie Aspose.Slides für Android via Java, um Kopf- und Fußzeilen in PowerPoint- und OpenDocument-Präsentationen hinzuzufügen und anzupassen, damit sie professionell aussehen."
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/de/androidjava/) bietet Unterstützung zur Arbeit mit Kopf‑ und Fußzeilentexten von Folien, die tatsächlich auf Folienmaster‑Ebene verwaltet werden.

{{% /alert %}} 

[Aspose.Slides for Android via Java](/slides/de/androidjava/) stellt die Funktion zum Verwalten von Kopf‑ und Fußzeilen innerhalb von Präsentationsfolien bereit. Diese werden tatsächlich auf Präsentations‑Master‑Ebene verwaltet.

## **Kopf‑ und Fußzeilen in einer Präsentation verwalten**
Notes of some specific slide could be removed as shown in example below:
```java
// Präsentation laden
Presentation pres = new Presentation("headerTest.pptx");
try {
    // Footer festlegen
    pres.getHeaderFooterManager().setAllFootersText("My Footer text");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);

    // Header zugreifen und aktualisieren
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
// Methode zum Setzen von Kopf-/Fußzeilentext
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


## **Kopf‑ und Fußzeilen in Handout‑ und Notizfolien verwalten**
Aspose.Slides for Android via Java unterstützt Kopf‑ und Fußzeilen in Handout‑ und Notizfolien. Bitte folgen Sie den untenstehenden Schritten:

- Laden Sie eine [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) die ein Video enthält.
- Ändern Sie die Kopf‑ und Fußzeileneinstellungen für den Notizen‑Master und alle Notizfolien.
- Machen Sie den Master‑Notizfolien und alle untergeordneten Fußzeilen‑Platzhalter sichtbar.
- Machen Sie den Master‑Notizfolien und alle untergeordneten Datums‑ und Zeit‑Platzhalter sichtbar.
- Ändern Sie die Kopf‑ und Fußzeileneinstellungen nur für die erste Notizfolie.
- Machen Sie den Kopfzeilen‑Platzhalter der Notizfolie sichtbar.
- Setzen Sie den Text des Kopfzeilen‑Platzhalters der Notizfolie.
- Setzen Sie den Text des Datums‑Zeit‑Platzhalters der Notizfolie.
- Schreiben Sie die modifizierte Präsentationsdatei.

Code‑Snippet im nachfolgenden Beispiel bereitgestellt.
```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // Header- und Fußzeileneinstellungen für den Notizen-Master und alle Notizenfolien ändern
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // den Master-Notizenfolien und alle untergeordneten Fußzeilen-Platzhalter sichtbar machen
        headerFooterManager.setFooterAndChildFootersVisibility(true); // den Master-Notizenfolien und alle untergeordneten Kopfzeilen-Platzhalter sichtbar machen
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // den Master-Notizenfolien und alle untergeordneten Foliennummern-Platzhalter sichtbar machen
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // den Master-Notizenfolien und alle untergeordneten Datum- und Zeit-Platzhalter sichtbar machen

        headerFooterManager.setHeaderAndChildHeadersText("Header text"); // Text für den Master-Notizenfolien und alle untergeordneten Kopfzeilen-Platzhalter festlegen
        headerFooterManager.setFooterAndChildFootersText("Footer text"); // Text für den Master-Notizenfolien und alle untergeordneten Fußzeilen-Platzhalter festlegen
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text"); // Text für den Master-Notizenfolien und alle untergeordneten Datum- und Zeit-Platzhalter festlegen
    }

    // Header- und Fußzeileneinstellungen nur für die erste Notizenfolie ändern
    INotesSlide notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null)
    {
        INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible())
            headerFooterManager.setHeaderVisibility(true); // diesen Notizenfolien-Kopfzeilen-Platzhalter sichtbar machen

        if (!headerFooterManager.isFooterVisible())
            headerFooterManager.setFooterVisibility(true); // diesen Notizenfolien-Fußzeilen-Platzhalter sichtbar machen

        if (!headerFooterManager.isSlideNumberVisible())
            headerFooterManager.setSlideNumberVisibility(true); // diesen Notizenfolien-Foliennummer-Platzhalter sichtbar machen

        if (!headerFooterManager.isDateTimeVisible())
            headerFooterManager.setDateTimeVisibility(true); // diesen Notizenfolien-Datum-Uhrzeit-Platzhalter sichtbar machen

        headerFooterManager.setHeaderText("New header text"); // Text für den Notizenfolien-Kopfzeilen-Platzhalter festlegen
        headerFooterManager.setFooterText("New footer text"); // Text für den Notizenfolien-Fußzeilen-Platzhalter festlegen
        headerFooterManager.setDateTimeText("New date and time text"); // Text für den Notizenfolien-Datum-Uhrzeit-Platzhalter festlegen
    }
    pres.save("testresult.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Kann ich eine "Kopfzeile" zu normalen Folien hinzufügen?**

In PowerPoint gibt es eine „Kopfzeile“ nur für Notizen und Handouts; auf normalen Folien sind die unterstützten Elemente Fußzeile, Datum/Uhrzeit und Foliennummer. In Aspose.Slides entsprechen die Einschränkungen denselben: Kopfzeile nur für Notizen/Handouts und auf Folien – Fußzeile/DatumUhrzeit/Foliennummer.

**Was, wenn das Layout keinen Fußzeilen‑Bereich enthält—kann ich seine Sichtbarkeit "einschalten"?**

Ja. Überprüfen Sie die Sichtbarkeit über den Kopf-/Fußzeilen‑Manager und aktivieren Sie sie bei Bedarf. Diese API‑Indikatoren und Methoden sind für Fälle gedacht, in denen der Platzhalter fehlt oder ausgeblendet ist.

**Wie kann ich die Foliennummer ab einem anderen Wert als 1 starten?**

Setzen Sie die [erste Foliennummer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) der Präsentation; danach wird die gesamte Nummerierung neu berechnet. Beispielsweise können Sie bei 0 oder 10 beginnen und die Nummer auf der Titelfolie ausblenden.

**Was passiert mit Kopf‑ und Fußzeilen beim Exportieren nach PDF/Bildern/HTML?**

Sie werden als reguläre Textelemente der Präsentation gerendert. Das heißt, wenn die Elemente auf Folien/Notizseiten sichtbar sind, erscheinen sie auch im Ausgabeformat zusammen mit dem restlichen Inhalt.