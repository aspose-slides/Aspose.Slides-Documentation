---
title: Präsentationskopf- und Fußzeile
type: docs
weight: 140
url: /de/nodejs-java/presentation-header-and-footer/
keywords: "PowerPoint Kopf- und Fußzeile in JavaScript"
description: "PowerPoint Kopf- und Fußzeile in JavaScript"
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/de/nodejs-java/) bietet Unterstützung zum Arbeiten mit Kopf‑ und Fußzeilentexten von Folien, die tatsächlich auf der Folienmasterebene verwaltet werden.

{{% /alert %}} 

[Aspose.Slides for Node.js via Java](/slides/de/nodejs-java/) stellt die Funktion zum Verwalten von Kopf‑ und Fußzeilen innerhalb von Präsentationsfolien bereit. Diese werden tatsächlich auf der Präsentationsmasterebene verwaltet.

## **Kopf‑ und Fußzeilen in Präsentation verwalten**
Notizen einer bestimmten Folie können wie im folgenden Beispiel entfernt werden:
```javascript
// Präsentation laden
var pres = new aspose.slides.Presentation("headerTest.pptx");
try {
    // Fußzeile festlegen
    pres.getHeaderFooterManager().setAllFootersText("My Footer text");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);
    // Kopfzeile zugreifen und aktualisieren
    var masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (null != masterNotesSlide) {
        updateHeaderFooterText(masterNotesSlide);
    }
    // Präsentation speichern
    pres.save("HeaderFooterJava.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
function updateHeaderFooterText(master) {
    let shapes = master.getShapes();
    for (let i = 0; i < shapes.size(); i++) {
        let shape = shapes.get_Item(i); 
        if (shape.getPlaceholder() !== null) {
            if (shape.getPlaceholder().getType() === aspose.PlaceholderType.Header) {
                shape.getTextFrame().setText("HI there new header");
            }
        }
    }
}
```


## **Kopf‑ und Fußzeilen in Handzetteln und Notizfolien verwalten**
Aspose.Slides für Node.js via Java unterstützt Kopf‑ und Fußzeilen in Handzetteln und Notizfolien. Bitte folgen Sie den untenstehenden Schritten:

- Laden Sie eine [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) mit einem Video.
- Ändern Sie die Kopf‑ und Fußzeileneinstellungen für den Notizenmaster und alle Notizfolien.
- Setzen Sie den Master‑Notizfolien‑Footer‑Platzhalter und alle untergeordneten Footer‑Platzhalter sichtbar.
- Setzen Sie den Master‑Notizfolien‑Datum‑und‑Uhrzeit‑Platzhalter und alle untergeordneten Datum‑und‑Uhrzeit‑Platzhalter sichtbar.
- Ändern Sie die Kopf‑ und Fußzeileneinstellungen nur für die erste Notizfolie.
- Setzen Sie den Header‑Platzhalter der Notizfolie sichtbar.
- Setzen Sie den Text für den Header‑Platzhalter der Notizfolie.
- Setzen Sie den Text für den Datum‑Uhrzeit‑Platzhalter der Notizfolie.
- Schreiben Sie die geänderte Präsentationsdatei.

Der Code‑Snippet ist im nachstehenden Beispiel enthalten.
```javascript
var pres = new aspose.slides.Presentation("presentation.pptx");
try {
    // Header- und Fußzeileneinstellungen für Notizenmaster und alle Notizfolien ändern
    var masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null) {
        var headerFooterManager = masterNotesSlide.getHeaderFooterManager();
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);// master Notizenfolie und alle untergeordneten Footer-Platzhalter sichtbar machen
        headerFooterManager.setFooterAndChildFootersVisibility(true);// master Notizenfolie und alle untergeordneten Header-Platzhalter sichtbar machen
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);// master Notizenfolie und alle untergeordneten Foliennummer-Platzhalter sichtbar machen
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);// master Notizenfolie und alle untergeordneten Datum-und-Uhrzeit-Platzhalter sichtbar machen
        headerFooterManager.setHeaderAndChildHeadersText("Header text");// Text für master Notizenfolie und alle untergeordneten Header-Platzhalter festlegen
        headerFooterManager.setFooterAndChildFootersText("Footer text");// Text für master Notizenfolie und alle untergeordneten Footer-Platzhalter festlegen
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");// Text für master Notizenfolie und alle untergeordneten Datum-und-Uhrzeit-Platzhalter festlegen
    }
    // Header- und Fußzeileneinstellungen nur für die erste Notizfolie ändern
    var notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null) {
        var headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible()) {
            headerFooterManager.setHeaderVisibility(true);
        }// diesen Notizfolien-Header-Platzhalter sichtbar machen
        if (!headerFooterManager.isFooterVisible()) {
            headerFooterManager.setFooterVisibility(true);
        }// diesen Notizfolien-Footer-Platzhalter sichtbar machen
        if (!headerFooterManager.isSlideNumberVisible()) {
            headerFooterManager.setSlideNumberVisibility(true);
        }// diesen Notizfolien-Foliennummer-Platzhalter sichtbar machen
        if (!headerFooterManager.isDateTimeVisible()) {
            headerFooterManager.setDateTimeVisibility(true);
        }// diesen Notizfolien-Datum-Uhrzeit-Platzhalter sichtbar machen
        headerFooterManager.setHeaderText("New header text");// Text für Notizfolien-Header-Platzhalter festlegen
        headerFooterManager.setFooterText("New footer text");// Text für Notizfolien-Footer-Platzhalter festlegen
        headerFooterManager.setDateTimeText("New date and time text");// Text für Notizfolien-Datum-Uhrzeit-Platzhalter festlegen
    }
    pres.save("testresult.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Kann ich einen „Header“ zu normalen Folien hinzufügen?**

In PowerPoint gibt es „Header“ nur für Notizen und Handzettel; bei normalen Folien sind die unterstützten Elemente Fußzeile, Datum/Uhrzeit und Foliennummer. In Aspose.Slides entspricht dies denselben Einschränkungen: Header nur für Notizen/Handzettel und bei Folien — Fußzeile/DatumUhrzeit/Foliennummer.

**Was ist, wenn das Layout keinen Fußzeilenbereich enthält – kann ich dessen Sichtbarkeit „aktivieren“?**

Ja. Überprüfen Sie die Sichtbarkeit über den Kopf‑/Fußzeilen‑Manager und aktivieren Sie sie bei Bedarf. Diese API‑Indikatoren und Methoden sind für Fälle vorgesehen, in denen der Platzhalter fehlt oder ausgeblendet ist.

**Wie kann ich die Foliennummer bei einem anderen Wert als 1 beginnen lassen?**

Setzen Sie die [erste Foliennummer](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/setfirstslidenumber/) der Präsentation; danach wird die gesamte Nummerierung neu berechnet. Zum Beispiel können Sie bei 0 oder 10 beginnen und die Nummer auf der Titelfolie ausblenden.

**Was passiert mit Kopf‑/Fußzeilen beim Exportieren zu PDF/Bildern/HTML?**

Sie werden als reguläre Textelemente der Präsentation gerendert. Das heißt, wenn die Elemente auf Folien/Notizseiten sichtbar sind, erscheinen sie auch im Ausgabformat zusammen mit dem restlichen Inhalt.