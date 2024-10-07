---
title: Präsentationsnotizen
type: docs
weight: 110
url: /java/presentation-notes/
keywords: "PowerPoint Referentennotizen in Java"
description: "Präsentationsnotizen, Referentennotizen in Java"
---


{{% alert color="primary" %}} 

Aspose.Slides unterstützt das Entfernen von Notizfolien aus einer Präsentation. In diesem Thema werden wir diese neue Funktion zum Entfernen von Notizen sowie das Hinzufügen von Notizenstilfolien aus jeder Präsentation einführen. 

{{% /alert %}} 

Aspose.Slides für Java bietet die Funktion, Notizen einer beliebigen Folie zu entfernen sowie bestehende Notizen zu gestalten. Entwickler können Notizen auf folgende Weise entfernen:

* Notizen einer bestimmten Folie einer Präsentation entfernen.
* Notizen aller Folien einer Präsentation entfernen.


## **Notizen von der Folie entfernen**
Notizen einer bestimmten Folie können wie im folgenden Beispiel gezeigt entfernt werden:

```java
// Erstellen Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Entfernen der Notizen der ersten Folie
    INotesSlideManager mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();

    // Präsentation auf die Festplatte speichern
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Notizen von der Präsentation entfernen**
Notizen aller Folien einer Präsentation können wie im folgenden Beispiel gezeigt entfernt werden:

```java
// Erstellen Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Entfernen der Notizen aller Folien
    INotesSlideManager mgr = null;
    for (int i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    
    // Präsentation auf die Festplatte speichern
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Notizenstil hinzufügen**
[getNotesStyle](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) Methode wurde der [IMasterNotesSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterNotesSlide) Schnittstelle und der [MasterNotesSlide](https://reference.aspose.com/slides/java/com.aspose.slides/MasterNotesSlide) Klasse hinzugefügt. Diese Eigenschaft gibt den Stil eines Notiztextes an. Die Implementierung wird im folgenden Beispiel demonstriert.

```java
// Erstellen Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // Holen Sie sich den Textstil der MasterNotesSlide
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        //Symbol-Aufzählungszeichen für die ersten Absatzebene setzen
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```