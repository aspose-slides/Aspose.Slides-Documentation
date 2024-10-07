---
title: Präsentationskopf und -fußzeile
type: docs
weight: 140
url: /androidjava/presentation-header-and-footer/
keywords: "PowerPoint Kopf- und Fußzeile in Java"
description: "PowerPoint Kopf- und Fußzeile in Java"
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/androidjava/) bietet Unterstützung zum Arbeiten mit dem Text der Kopf- und Fußzeilen von Folien, die tatsächlich auf der Folienmaster-Ebene verwaltet werden.

{{% /alert %}} 

[Aspose.Slides für Android über Java](/slides/androidjava/) bietet die Funktion zum Verwalten von Kopf- und Fußzeilen in Präsentationsfolien. Diese werden tatsächlich auf der Präsentationsmaster-Ebene verwaltet.

## **Kopf- und Fußzeile in der Präsentation verwalten**
Die Notizen einiger spezifischer Folien können entfernt werden, wie im folgenden Beispiel gezeigt:

```java
// Präsentation laden
Presentation pres = new Presentation("headerTest.pptx");
try {
    // Fußzeile einstellen
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
// Methode zum Setzen von Kopf-/Fußzeilentext
public static void updateHeaderFooterText(IBaseSlide master)
{
    for (IShape shape : master.getShapes())
    {
        if (shape.getPlaceholder() != null)
        {
            if (shape.getPlaceholder().getType() == PlaceholderType.Header)
            {
                ((IAutoShape)shape).getTextFrame().setText("Hallo neuer Header");
            }
        }
    }
}
```

## **Kopf- und Fußzeile in Handouts und Notizenfolien verwalten**
Aspose.Slides für Android über Java unterstützt Kopf- und Fußzeilen in Handouts und Notizenfolien. Bitte befolgen Sie die folgenden Schritte:

- Laden Sie eine [Präsentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) mit einem Video.
- Ändern Sie die Einstellungen für Kopf- und Fußzeilen für den Notizenmaster und alle Notizenfolien.
- Machen Sie die Master-Notizenfolie und alle Kind-Fußzeilenplatzhalter sichtbar.
- Machen Sie die Master-Notizenfolie und alle Kind-Datum- und Zeitplatzhalter sichtbar.
- Ändern Sie die Einstellungen für Kopf- und Fußzeilen nur für die erste Notizenfolie.
- Machen Sie den Kopfzeilenplatzhalter der Notizenfolie sichtbar.
- Setzen Sie den Text für den Kopfzeilenplatzhalter der Notizenfolie.
- Setzen Sie den Text für den Datum-Uhrzeit-Platzhalter der Notizenfolie.
- Schreiben Sie die modifizierte Präsentationsdatei.

Der Codeauszug ist im folgenden Beispiel enthalten.

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // Ändern Sie die Einstellungen für Kopf- und Fußzeilen für den Notizenmaster und alle Notizenfolien
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // Master-Notizenfolie und alle Kind-Fußzeilenplatzhalter sichtbar machen
        headerFooterManager.setFooterAndChildFootersVisibility(true); // Master-Notizenfolie und alle Kind-Kopfzeilenplatzhalter sichtbar machen
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // Master-Notizenfolie und alle Kind-Foliennummernplatzhalter sichtbar machen
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // Master-Notizenfolie und alle Kind-Datum- und Zeitplatzhalter sichtbar machen

        headerFooterManager.setHeaderAndChildHeadersText("Kopfzeilentext"); // Text für Master-Notizenfolie und alle Kind-Kopfzeilenplatzhalter setzen
        headerFooterManager.setFooterAndChildFootersText("Fußzeilentext"); // Text für Master-Notizenfolie und alle Kind-Fußzeilenplatzhalter setzen
        headerFooterManager.setDateTimeAndChildDateTimesText("Datum und Zeittext"); // Text für Master-Notizenfolie und alle Kind-Datum- und Zeitplatzhalter setzen
    }

    // Ändern Sie die Einstellungen für Kopf- und Fußzeilen nur für die erste Notizenfolie
    INotesSlide notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null)
    {
        INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible())
            headerFooterManager.setHeaderVisibility(true); // diesen Notizenfolien Kopfzeilenplatzhalter sichtbar machen

        if (!headerFooterManager.isFooterVisible())
            headerFooterManager.setFooterVisibility(true); // diesen Notizenfolien Fußzeilenplatzhalter sichtbar machen

        if (!headerFooterManager.isSlideNumberVisible())
            headerFooterManager.setSlideNumberVisibility(true); // diesen Notizenfolien Foliennummernplatzhalter sichtbar machen

        if (!headerFooterManager.isDateTimeVisible())
            headerFooterManager.setDateTimeVisibility(true); // diesen Notizenfolien Datum-Uhrzeit-Platzhalter sichtbar machen

        headerFooterManager.setHeaderText("Neuer Kopfzeilentext"); // Text für Notizenfolien Kopfzeilenplatzhalter setzen
        headerFooterManager.setFooterText("Neuer Fußzeilentext"); // Text für Notizenfolien Fußzeilenplatzhalter setzen
        headerFooterManager.setDateTimeText("Neuer Datum- und Zeittext"); // Text für Notizenfolien Datum-Uhrzeit-Platzhalter setzen
    }
    pres.save("testresult.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```