---
title: Manage Presentation Notes in .NET
linktitle: Presentation Notes
type: docs
weight: 110
url: /de/net/presentation-notes/
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
- .NET
- C#
- Aspose.Slides
description: "Passen Sie Präsentationsnotizen mit Aspose.Slides für .NET an. Arbeiten Sie nahtlos mit PowerPoint- und OpenDocument-Notizen, um Ihre Produktivität zu steigern."
---
## **Übersicht**

Aspose.Slides unterstützt das Entfernen von Notizfolien aus einer Präsentation. In diesem Thema stellen wir diese Funktion vor, einschließlich wie man Notizen entfernt und wie man einen Stil auf Notizfolien in einer Präsentation anwendet. Aspose.Slides ermöglicht das Entfernen von Notizen von beliebigen Folien und ebenfalls das Anwenden von Formatierungen auf vorhandene Notizen. Entwickler können Notizen auf folgende Weise entfernen:

- Entfernen Sie Notizen von einer bestimmten Folie in einer Präsentation.
- Entfernen Sie Notizen von allen Folien in einer Präsentation.

Um die Abmessungen der Notizenseite zu lesen oder zu ändern, die Ausrichtung zu wechseln und das Exportverhalten zu prüfen, siehe [Notes Page Size](/slides/de/net/notes-size/).

## **Notizen von einer Folie entfernen**
Notizen einer bestimmten Folie können wie im folgenden Beispiel entfernt werden:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
Presentation presentation = new Presentation("AccessSlides.pptx");

// Entfernen von Notizen der ersten Folie
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// Präsentation auf Festplatte speichern
presentation.Save("RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```

## **Notizen von allen Folien entfernen**
Notizen aller Folien einer Präsentation können wie im folgenden Beispiel entfernt werden:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt 
Presentation presentation = new Presentation("AccessSlides.pptx");

// Entfernen von Notizen aller Folien
INotesSlideManager mgr = null;
for (int i = 0; i < presentation.Slides.Count; i++)
{
    mgr = presentation.Slides[i].NotesSlideManager;
    mgr.RemoveNotesSlide();
}
// Präsentation auf Festplatte speichern
presentation.Save("RemoveNotesFromAllSlides_out.pptx", SaveFormat.Pptx);
```

## **Ein Notizstil hinzufügen**
Die NotesStyle‑Eigenschaft wurde dem [IMasterNotesSlide](https://reference.aspose.com/slides/de/net/aspose.slides/imasternotesslide) Interface und der [MasterNotesSlide](https://reference.aspose.com/slides/de/net/aspose.slides/masternotesslide) Klasse hinzugefügt. Diese Eigenschaft legt den Stil eines Notiztexts fest. Die Implementierung wird im folgenden Beispiel gezeigt.

```c#
using Aspose.Slides;

// Instanziieren Sie die Presentation‑Klasse, die die Präsentationsdatei darstellt
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

    if (notesMaster != null)
    {
        // Holen Sie den Textstil der MasterNotesSlide
        ITextStyle notesStyle = notesMaster.NotesStyle;

        // Symbol‑Aufzählungszeichen für die Absätze der ersten Ebene festlegen
        IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
        paragraphFormat.Bullet.Type = BulletType.Symbol;
    }

    // Speichern Sie die PPTX‑Datei auf der Festplatte
    presentation.Save("AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

}
```

## **FAQ**

### Welche API‑Entität ermöglicht den Zugriff auf die Notizen einer bestimmten Folie?
Auf Notizen wird über den Notiz‑Manager der Folie zugegriffen: Die Folie verfügt über einen [NotesSlideManager](https://reference.aspose.com/slides/de/net/aspose.slides/notesslidemanager/) und eine [property](https://reference.aspose.com/slides/de/net/aspose.slides/notesslidemanager/notesslide/), die das Notizobjekt zurückgibt, oder `null`, wenn keine Notizen vorhanden sind.

### Gibt es Unterschiede in der Notizunterstützung zwischen den PowerPoint‑Versionen, mit denen die Bibliothek arbeitet?
Die Bibliothek richtet sich an ein breites Spektrum von Microsoft‑PowerPoint‑Formaten (97–neuere) und ODP; Notizen werden in diesen Formaten unterstützt, ohne dass eine installierte Kopie von PowerPoint erforderlich ist.