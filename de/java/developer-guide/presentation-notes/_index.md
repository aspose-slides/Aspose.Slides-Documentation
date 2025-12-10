---
title: Verwalten von Präsentationsnotizen in Java
linktitle: Präsentationsnotizen
type: docs
weight: 110
url: /de/java/presentation-notes/
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
- Java
- Aspose.Slides
description: "Passen Sie Präsentationsnotizen mit Aspose.Slides für Java an. Arbeiten Sie nahtlos mit PowerPoint- und OpenDocument-Notizen, um Ihre Produktivität zu steigern."
---

{{% alert color="primary" %}} 

Aspose.Slides unterstützt das Entfernen von Notizfolien aus einer Präsentation. In diesem Thema stellen wir diese neue Funktion zum Entfernen von Notizen sowie zum Hinzufügen von Notizstilfolien zu einer beliebigen Präsentation vor. 

{{% /alert %}} 

Aspose.Slides für Java bietet die Möglichkeit, Notizen einer beliebigen Folie zu entfernen und vorhandenen Notizen einen Stil zuzuweisen. Entwickler können Notizen auf folgende Arten entfernen:

* Entfernen von Notizen einer bestimmten Folie einer Präsentation.
* Entfernen von Notizen aller Folien einer Präsentation


## **Notizen von einer Folie entfernen**
Notizen einer bestimmten Folie können wie im folgenden Beispiel entfernt werden:
```java
// Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Entfernen der Notizen der ersten Folie
    INotesSlideManager mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();

    // Speichern der Präsentation auf dem Datenträger
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Notizen aus einer Präsentation entfernen**
Notizen aller Folien einer Präsentation können wie im folgenden Beispiel entfernt werden:
```java
// Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Entfernen der Notizen aller Folien
    INotesSlideManager mgr = null;
    for (int i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    
    // Speichern der Präsentation auf dem Datenträger
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Einen Notizstil hinzufügen**
[getNotesStyle](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) Methode wurde dem [IMasterNotesSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterNotesSlide) Interface und der [MasterNotesSlide](https://reference.aspose.com/slides/java/com.aspose.slides/MasterNotesSlide) Klasse hinzugefügt. Diese Eigenschaft gibt den Stil eines Notiztextes an. Die Implementierung wird im folgenden Beispiel gezeigt.
```java
// Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // MasterNotesSlide-Textstil abrufen
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        // Symbol-Listenzeichen für Absätze der ersten Ebene festlegen
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Welches API-Entität stellt den Zugriff auf die Notizen einer bestimmten Folie bereit?**

Notizen werden über den Notiz‑Manager der Folie abgerufen: Die Folie besitzt einen [NotesSlideManager](https://reference.aspose.com/slides/java/com.aspose.slides/notesslidemanager/) und eine [Methode](https://reference.aspose.com/slides/java/com.aspose.slides/notesslidemanager/#getNotesSlide--) , die das Notizobjekt zurückgibt oder `null`, wenn keine Notizen vorhanden sind.

**Gibt es Unterschiede in der Notizunterstützung zwischen den PowerPoint-Versionen, mit denen die Bibliothek arbeitet?**

Die Bibliothek unterstützt ein breites Spektrum an Microsoft‑PowerPoint‑Formaten (97 – neuere) sowie ODP; Notizen werden in diesen Formaten unterstützt, ohne dass eine installierte Kopie von PowerPoint erforderlich ist.