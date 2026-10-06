---
title: Verwalten von Präsentationsnotizen in JavaScript
linktitle: Präsentationsnotizen
type: docs
weight: 110
url: /de/nodejs-java/presentation-notes/
keywords:
- Notizen
- Notizfolie
- Notizen hinzufügen
- Notizen entfernen
- Notizstil
- Master-Notizen
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Passen Sie Präsentationsnotizen in JavaScript mit Aspose.Slides für Node.js an. Arbeiten Sie nahtlos mit PowerPoint- und OpenDocument-Notizen, um Ihre Produktivität zu steigern."
---
## **Übersicht**

Aspose.Slides unterstützt das Entfernen von Notizfolien aus einer Präsentation. In diesem Thema stellen wir diese Funktion vor, einschließlich wie man Notizen entfernt und wie man einen Stil auf Notizfolien in einer Präsentation anwendet. Aspose.Slides ermöglicht das Entfernen von Notizen von beliebigen Folien und das Anwenden von Formatierungen auf vorhandene Notizen. Entwickler können Notizen auf folgende Weise entfernen:

- Notizen von einer bestimmten Folie in einer Präsentation entfernen.
- Notizen von allen Folien in einer Präsentation entfernen.

Um die Abmessungen der Notizseite zu lesen oder zu ändern, die Ausrichtung zu wechseln und das Exportverhalten zu prüfen, siehe [Größe der Notizseite](/slides/de/nodejs-java/notes-size/).

## **Notizen von einer Folie entfernen**
Notizen von einer bestimmten Folie können wie im folgenden Beispiel entfernt werden:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // Entfernen der Notizen der ersten Folie
    var mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();
    // Speichern der Präsentation auf dem Datenträger
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Notizen aus einer Präsentation entfernen**
Notizen von allen Folien in einer Präsentation können wie im folgenden Beispiel entfernt werden:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // Entfernen der Notizen aller Folien
    var mgr = null;
    for (var i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    // Speichern der Präsentation auf dem Datenträger
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **NotesStyle hinzufügen**
[getNotesStyle](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/MasterNotesSlide#getNotesStyle--) Methode wurde zur Klasse [MasterNotesSlide](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/MasterNotesSlide) und zur Klasse [MasterNotesSlide](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/MasterNotesSlide) hinzugefügt. Diese Eigenschaft gibt den Stil eines Notiztextes an. Die Implementierung wird im folgenden Beispiel gezeigt.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    var notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        // Holen Sie den Textstil von MasterNotesSlide
        var notesStyle = notesMaster.getNotesStyle();
        // Setzen Sie ein Symbol-Aufzählungszeichen für die Absätze der ersten Ebene
        var paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    }
    pres.save("NotesSlideWithNotesStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Welches API-Entität stellt den Zugriff auf die Notizen einer bestimmten Folie bereit?**

Notizen werden über den Notiz-Manager der Folie abgerufen: Die Folie verfügt über einen [NotesSlideManager](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/notesslidemanager/) und eine [Methode](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/notesslidemanager/getnotesslide/), die das Notizobjekt zurückgibt, oder `null`, wenn keine Notizen vorhanden sind.

**Gibt es Unterschiede in der Notizunterstützung zwischen den PowerPoint-Versionen, mit denen die Bibliothek arbeitet?**

Die Bibliothek unterstützt ein breites Spektrum von Microsoft PowerPoint-Formaten (97–neuere) sowie ODP; Notizen werden in diesen Formaten unterstützt, ohne dass eine installierte Kopie von PowerPoint erforderlich ist.