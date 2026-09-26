---
title: Präsentationsnotizen verwalten in Java
linktitle: Präsentationsnotizen
type: docs
weight: 110
url: /de/java/presentation-notes/
keywords:
- notizen
- notizfolie
- notizen hinzufügen
- notizen entfernen
- notizstil
- masternotizen
- PowerPoint
- OpenDocument
- präsentation
- Java
- Aspose.Slides
description: "Passen Sie Präsentationsnotizen mit Aspose.Slides für Java an. Arbeiten Sie nahtlos mit PowerPoint- und OpenDocument-Notizen, um Ihre Produktivität zu steigern."
---
## **Übersicht**

Aspose.Slides unterstützt das Entfernen von Notizfolien aus einer Präsentation. In diesem Thema stellen wir diese Funktion vor, einschließlich des Entfernens von Notizen und des Anwendens eines Stils auf Notizfolien in einer Präsentation. Aspose.Slides ermöglicht das Entfernen von Notizen von jeder Folie und das Anwenden von Formatierungen auf vorhandene Notizen. Entwickler können Notizen auf folgende Arten entfernen:

- Notizen von einer bestimmten Folie in einer Präsentation entfernen.
- Notizen von allen Folien in einer Präsentation entfernen.

Um die Abmessungen der Notizseite zu lesen oder zu ändern, die Ausrichtung zu wechseln und das Exportverhalten zu prüfen, siehe [Notizseitengröße](/slides/de/java/notes-size/).

## **Notizen von einer Folie entfernen**
Notizen von einer bestimmten Folie können wie im nachstehenden Beispiel entfernt werden:

```java
import com.aspose.slides.*;

// Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Entfernen von Notizen der ersten Folie
    INotesSlideManager mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();

    // Präsentation auf Festplatte speichern
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Notizen aus einer Präsentation entfernen**
Notizen von allen Folien in einer Präsentation können wie im nachstehenden Beispiel entfernt werden:

```java
import com.aspose.slides.*;

// Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Entfernen von Notizen aller Folien
    INotesSlideManager mgr = null;
    for (int i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    
    // Präsentation auf Festplatte speichern
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Notizstil hinzufügen**
Die Methode [getNotesStyle](https://reference.aspose.com/slides/de/java/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) wurde zur Schnittstelle [IMasterNotesSlide](https://reference.aspose.com/slides/de/java/com.aspose.slides/IMasterNotesSlide) und zur Klasse [MasterNotesSlide](https://reference.aspose.com/slides/de/java/com.aspose.slides/MasterNotesSlide) hinzugefügt. Diese Eigenschaft gibt den Stil eines Notiztextes an. Die Implementierung wird im nachstehenden Beispiel gezeigt.

```java
import com.aspose.slides.*;

// Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // MasterNotesSlide-Textstil abrufen
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        // Symbol-Aufzählungszeichen für die Absätze der ersten Ebene festlegen
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Welches API-Entität bietet Zugriff auf die Notizen einer bestimmten Folie?**

Notizen werden über den Notiz-Manager der Folie abgerufen: Die Folie verfügt über einen [NotesSlideManager](https://reference.aspose.com/slides/de/java/com.aspose.slides/notesslidemanager/) und eine [Methode](https://reference.aspose.com/slides/de/java/com.aspose.slides/notesslidemanager/#getNotesSlide--) die das Notizobjekt zurückgibt, oder `null`, wenn keine Notizen vorhanden sind.

**Gibt es Unterschiede in der Notizunterstützung zwischen den PowerPoint‑Versionen, mit denen die Bibliothek arbeitet?**

Die Bibliothek unterstützt ein breites Spektrum von Microsoft PowerPoint‑Formaten (97-neuer) und ODP; Notizen werden in diesen Formaten unterstützt, ohne dass eine installierte Kopie von PowerPoint erforderlich ist.