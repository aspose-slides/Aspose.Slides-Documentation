---
title: Verwalten von Präsentationsnotizen auf Android
linktitle: Präsentationsnotizen
type: docs
weight: 110
url: /de/androidjava/presentation-notes/
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
- Android
- Java
- Aspose.Slides
description: "Passen Sie Präsentationsnotizen mit Aspose.Slides für Android via Java an. Arbeiten Sie nahtlos mit PowerPoint- und OpenDocument-Notizen, um Ihre Produktivität zu steigern."
---

{{% alert color="primary" %}} 

Aspose.Slides unterstützt das Entfernen von Notizfolien aus einer Präsentation. In diesem Thema stellen wir diese neue Funktion zum Entfernen von Notizen sowie das Hinzufügen von Notizformatfolien aus einer beliebigen Präsentation vor. 

{{% /alert %}} 

Aspose.Slides für Android via Java bietet die Möglichkeit, Notizen einer beliebigen Folie zu entfernen sowie Stil zu vorhandenen Notizen hinzuzufügen. Entwickler können Notizen auf folgende Weise entfernen:

* Entfernen von Notizen einer bestimmten Folie einer Präsentation.
* Entfernen von Notizen aller Folien einer Präsentation


## **Notizen von einer Folie entfernen**
Notizen einer bestimmten Folie können wie im nachstehenden Beispiel entfernt werden:
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


## **Notizen einer Präsentation entfernen**
Notizen aller Folien einer Präsentation können wie im nachstehenden Beispiel entfernt werden:
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


## **Notizstil hinzufügen**
Die Methode [getNotesStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) wurde dem Interface [IMasterNotesSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterNotesSlide) und der Klasse [MasterNotesSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MasterNotesSlide) jeweils hinzugefügt. Diese Eigenschaft legt den Stil eines Notiztextes fest. Die Implementierung wird im nachstehenden Beispiel gezeigt.
```java
// Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // Abrufen des Textstils der MasterNotesSlide
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        //Setze Symbol-Aufzählungszeichen für Absätze der ersten Ebene
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Welche API‑Entität bietet Zugriff auf die Notizen einer bestimmten Folie?**

Auf Notizen wird über den Notiz‑Manager der Folie zugegriffen: Die Folie verfügt über einen [NotesSlideManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/notesslidemanager/) und eine [Methode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/notesslidemanager/#getNotesSlide--) , die das Notiz‑Objekt zurückgibt, oder `null`, falls keine Notizen vorhanden sind.

**Gibt es Unterschiede in der Notizunterstützung zwischen den PowerPoint‑Versionen, mit denen die Bibliothek arbeitet?**

Die Bibliothek unterstützt ein breites Spektrum an Microsoft‑PowerPoint‑Formaten (97–neuere) sowie ODP; Notizen werden in diesen Formaten unterstützt, ohne dass eine installierte Kopie von PowerPoint erforderlich ist.