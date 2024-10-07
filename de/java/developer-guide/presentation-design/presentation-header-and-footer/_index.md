---
title: Präsentationskopf und -fußzeile
type: docs
weight: 140
url: /java/presentation-header-and-footer/
keywords: "PowerPoint Kopf- und Fußzeile in Java"
description: "PowerPoint Kopf- und Fußzeile in Java"
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/java/) bietet Unterstützung zum Arbeiten mit den Texten der Kopf- und Fußzeilen, die tatsächlich auf der Masterfolie der Folien verwaltet werden.

{{% /alert %}} 

[Aspose.Slides für Java](/slides/java/) bietet die Funktion zum Verwalten von Kopf- und Fußzeilen in Präsentationsfolien. Diese werden tatsächlich auf der Präsentationsmasterfolie verwaltet.

## **Kopf- und Fußzeile in der Präsentation verwalten**
Die Notizen einer bestimmten Folie können entfernt werden, wie im folgenden Beispiel gezeigt:

```java
// Präsentation laden
Presentation pres = new Presentation("headerTest.pptx");
try {
    // Fußzeile setzen
    pres.getHeaderFooterManager().setAllFootersText("Mein Fußzeilentext");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);

    // Kopfzeile abrufen und aktualisieren
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
// Methode zum Setzen des Kopf- / Fußzeilentextes
public static void updateHeaderFooterText(IBaseSlide master)
{
    for (IShape shape : master.getShapes())
    {
        if (shape.getPlaceholder() != null)
        {
            if (shape.getPlaceholder().getType() == PlaceholderType.Header)
            {
                ((IAutoShape)shape).getTextFrame().setText("Hallo neuer Kopf");
            }
        }
    }
}
```

## **Kopf- und Fußzeile in Handouts und Notizenfolien verwalten**
Aspose.Slides für Java unterstützt Kopf- und Fußzeilen in Handouts und Notizenfolien. Bitte folgen Sie den folgenden Schritten:

- Laden Sie eine [Präsentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation), die ein Video enthält.
- Ändern Sie die Einstellungen für Kopf- und Fußzeilen für die Notizmasterfolie und alle Notizfolien.
- Setzen Sie die Master-Notizfolie und alle untergeordneten Fußzeilenplatzhalter sichtbar.
- Setzen Sie die Master-Notizfolie und alle untergeordneten Datums- und Zeitplatzhalter sichtbar.
- Ändern Sie die Einstellungen für Kopf- und Fußzeilen nur für die erste Notizfolie.
- Setzen Sie den Kopfzeilenplatzhalter der Notizfolie sichtbar.
- Setzen Sie den Text für den Kopfzeilenplatzhalter der Notizfolie.
- Setzen Sie den Text für den Datums- und Zeitplatzhalter der Notizfolie.
- Schreiben Sie die modifizierte Präsentationsdatei.

Der Codeausschnitt ist im folgenden Beispiel enthalten.

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // Ändern Sie die Einstellungen für Kopf- und Fußzeilen für die Notizmasterfolie und alle Notizfolien
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // Master-Notizfolie und alle untergeordneten Fußzeilenplatzhalter sichtbar machen
        headerFooterManager.setFooterAndChildFootersVisibility(true); // Master-Notizfolie und alle untergeordneten Kopfzeilenplatzhalter sichtbar machen
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // Master-Notizfolie und alle untergeordneten Foliennummern sichtbar machen
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // Master-Notizfolie und alle untergeordneten Datums- und Zeitplatzhalter sichtbar machen

        headerFooterManager.setHeaderAndChildHeadersText("Kopfzeilentext"); // Text für Master-Notizfolie und alle untergeordneten Kopfzeilenplatzhalter festlegen
        headerFooterManager.setFooterAndChildFootersText("Fußzeilentext"); // Text für Master-Notizfolie und alle untergeordneten Fußzeilenplatzhalter festlegen
        headerFooterManager.setDateTimeAndChildDateTimesText("Datum und Zeittext"); // Text für Master-Notizfolie und alle untergeordneten Datums- und Zeitplatzhalter festlegen
    }

    // Ändern Sie die Einstellungen für Kopf- und Fußzeilen nur für die erste Notizfolie
    INotesSlide notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null)
    {
        INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible())
            headerFooterManager.setHeaderVisibility(true); // diesen Notizfolienkopfzeilenplatzhalter sichtbar machen

        if (!headerFooterManager.isFooterVisible())
            headerFooterManager.setFooterVisibility(true); // diesen Notizfolienfußzeilenplatzhalter sichtbar machen

        if (!headerFooterManager.isSlideNumberVisible())
            headerFooterManager.setSlideNumberVisibility(true); // diesen Notizfolienfoliennummernplatzhalter sichtbar machen

        if (!headerFooterManager.isDateTimeVisible())
            headerFooterManager.setDateTimeVisibility(true); // diesen Notizfolien-Datum-und-Zeitplatzhalter sichtbar machen

        headerFooterManager.setHeaderText("Neuer Kopfzeilentext"); // Text für den Kopfzeilenplatzhalter der Notizfolie festlegen
        headerFooterManager.setFooterText("Neuer Fußzeilentext"); // Text für den Fußzeilenplatzhalter der Notizfolie festlegen
        headerFooterManager.setDateTimeText("Neuer Datum- und Zeittext"); // Text für den Datum- und Zeitplatzhalter der Notizfolie festlegen
    }
    pres.save("testresult.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```