---
title: Präsentationsnotizen verwalten auf Android
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
## **Übersicht**

Aspose.Slides unterstützt das Entfernen von Notizfolien aus einer Präsentation. In diesem Thema stellen wir diese Funktion vor, einschließlich wie Notizen entfernt werden und wie ein Stil auf Notizfolien in einer Präsentation angewendet wird. Aspose.Slides ermöglicht das Entfernen von Notizen von jeder Folie und auch das Anwenden von Formatierungen auf vorhandene Notizen. Entwickler können Notizen auf folgende Weise entfernen:

- Notizen von einer bestimmten Folie in einer Präsentation entfernen.
- Notizen von allen Folien in einer Präsentation entfernen.

Um die Abmessungen der Notizseite zu lesen oder zu ändern, die Ausrichtung zu wechseln und das Exportverhalten zu prüfen, siehe [Notizseitengröße](/slides/de/androidjava/notes-size/).

## **Notizen von einer Folie entfernen**
Notizen von einer bestimmten Folie können wie im folgenden Beispiel entfernt werden:

```java
import com.aspose.slides.*;

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
Notizen von allen Folien in einer Präsentation können wie im folgenden Beispiel entfernt werden:

```java
import com.aspose.slides.*;

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
[getNotesStyle](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IMasterNotesSlide#getNotesStyle--)‑Methode wurde dem [IMasterNotesSlide](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IMasterNotesSlide)‑Interface und der [MasterNotesSlide](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/MasterNotesSlide)‑Klasse jeweils hinzugefügt. Diese Eigenschaft gibt den Stil eines Notiztexts an. Die Implementierung wird im folgenden Beispiel demonstriert.

```java
import com.aspose.slides.*;

// Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // Hole den Textstil der MasterNotesSlide
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        //Setze Symbolaufzählungszeichen für Absätze der ersten Ebene
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

Notizen werden über den Notiz‑Manager der Folie abgerufen: Die Folie verfügt über einen [NotesSlideManager](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/notesslidemanager/) und eine [Methode](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/notesslidemanager/#getNotesSlide--) die das Notizobjekt zurückgibt, oder `null`, wenn keine Notizen vorhanden sind.

**Gibt es Unterschiede in der Notizunterstützung zwischen den PowerPoint‑Versionen, mit denen die Bibliothek arbeitet?**

Die Bibliothek unterstützt ein breites Spektrum an Microsoft‑PowerPoint‑Formaten (97–neuere) und ODP; Notizen werden in diesen Formaten unterstützt, ohne dass eine installierte Kopie von PowerPoint erforderlich ist.