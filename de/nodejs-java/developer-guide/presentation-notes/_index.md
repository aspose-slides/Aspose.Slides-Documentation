---
title: Präsentationsnotizen
type: docs
weight: 110
url: /de/nodejs-java/presentation-notes/
keywords: "PowerPoint-Rednernotizen in JavaScript"
description: "Präsentationsnotizen, Rednernotizen in JavaScript"
---

{{% alert color="primary" %}} 

Aspose.Slides unterstützt das Entfernen von Notizfolien aus einer Präsentation. In diesem Thema stellen wir diese neue Funktion zum Entfernen von Notizen sowie zum Hinzufügen von Notizstil‑Folien aus jeder Präsentation vor. 

{{% /alert %}} 

Aspose.Slides für Node.js via Java bietet die Möglichkeit, Notizen einer beliebigen Folie zu entfernen und vorhandenen Notizen Stil hinzuzufügen. Entwickler können Notizen auf die folgenden Arten entfernen:

* Entfernen Sie Notizen einer bestimmten Folie einer Präsentation.  
* Entfernen Sie Notizen aller Folien einer Präsentation  


## **Notizen von Folie entfernen**
Notizen einer bestimmten Folie können wie im folgenden Beispiel entfernt werden:
```javascript
// Erzeugen Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
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


## **Notizen aus Präsentation entfernen**
Notizen aller Folien einer Präsentation können wie im folgenden Beispiel entfernt werden:
```javascript
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


## **Notizstil hinzufügen**
[getNotesStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterNotesSlide#getNotesStyle--)‑Methode wurde zur Klasse [MasterNotesSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterNotesSlide) hinzugefügt. Diese Eigenschaft gibt den Stil eines Notiztextes an. Die Implementierung wird im folgenden Beispiel gezeigt.
```javascript
// Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    var notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        // MasterNotesSlide-Textstil abrufen
        var notesStyle = notesMaster.getNotesStyle();
        // Symbol-Aufzählungszeichen für Absätze der ersten Ebene festlegen
        var paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(aspose.slides.BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Welches API‑Entität bietet Zugriff auf die Notizen einer bestimmten Folie?**

Notizen werden über den Notiz‑Manager der Folie abgerufen: Die Folie hat einen [NotesSlideManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notesslidemanager/) und eine [getNotesSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notesslidemanager/getnotesslide/)‑Methode, die das Notizobjekt zurückgibt, oder `null`, wenn keine Notizen vorhanden sind.

**Gibt es Unterschiede in der Notizunterstützung zwischen den PowerPoint‑Versionen, mit denen die Bibliothek arbeitet?**

Die Bibliothek richtet sich an ein breites Spektrum von Microsoft PowerPoint‑Formaten (97‑neuere) und ODP; Notizen werden in diesen Formaten unterstützt, ohne dass eine installierte Kopie von PowerPoint erforderlich ist.